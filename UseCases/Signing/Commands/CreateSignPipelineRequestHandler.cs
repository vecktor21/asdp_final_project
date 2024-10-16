using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Services;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequestHandler : IRequestHandler<CreateSignPipelineRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SigexApi _sigexApi;
        private readonly AdspContext _context;

        public CreateSignPipelineRequestHandler(IUnitOfWork unitOfWork, IMapper mapper,
            SigexApi sigexApi)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sigexApi = sigexApi;
            _context = unitOfWork.GetContext();
        }
        public async Task Handle(CreateSignPipelineRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction();
            try
            {

                var signDocument = new SignDocument
                {
                    Name = request.GeneratedDocument.Name
                };
                using (var ms = new MemoryStream())
                {
                    request.GeneratedDocument.CopyTo(ms);
                    signDocument.Content = ms.ToArray();
                }

                var signPipeline = new SignPipeline
                {
                    SignDocument = signDocument,
                    Status = Constants.SignPipelineStatus.Created,
                    CreatorEmployeeId = request.UserId
                };

                var signers = await _context.Employees
                    .Include(x => x.Position)
                    .ThenInclude(x => x.Permissions)
                    .Where(x => x.Position.Permissions.Any(a => a.Code == PermissionCodes.SignDocuments))
                    .ToListAsync();

                var teamlid = signers.Where(x=> x.Position.Code == PositionCode.Teamlid).First();
                var director = signers.Where(x => x.Position.Code == PositionCode.Director).First();

                var signerEmployees = new List<SignerToPipeline>()
                {
                    new SignerToPipeline
                    {
                        SignerEmployee = teamlid,
                        Order = 1,
                        SignPipeline = signPipeline,
                        IsSigned = false
                    },

                    new SignerToPipeline
                    {
                        SignerEmployee = director,
                        Order = 2,
                        SignPipeline = signPipeline,
                        IsSigned = false
                    }
                };

                signPipeline.Signers = signerEmployees;

                var template = _context.Templates.Where(x => x.Id == request.TemplateId).Single();

                var registerResult = await _sigexApi.RegisterNewDocument(new SigexRegisterNewDocumentRequest
                {
                    emailNotifications = new SigexEmailNotifications
                    {
                        to = new List<string>() { teamlid.Mail, director.Mail },
                        doNotAttachDocument = false,
                    },
                    signature = request.CmsSign,
                    signType = "cms",
                    title = template.Name,
                    settings = new SigexDocumentSettingsDto
                    {
                        forceArchive = true,
                        sequentialSignersRequirements=true,
                        signersRequirements = new List<SigexSignersRequirementsDto>
                        {
                            new SigexSignersRequirementsDto
                            {
                                iin = $"IIN{teamlid.Iin}",
                                //ca = "nca",
                            },
                            new SigexSignersRequirementsDto
                            {
                                iin = $"IIN{director.Iin}",
                                //ca = "nca",
                            }
                        }
                    }
                });

                var saveResult = await _sigexApi.SaveDocument(registerResult.documentId, new ByteArrayContent(signDocument.Content));

                _context.SignPipeline.Add(signPipeline);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
            _unitOfWork.CommitTransaction();

        }
    }
}
