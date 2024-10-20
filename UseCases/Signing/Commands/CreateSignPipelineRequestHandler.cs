using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Dtos.Sigex;
using ASDP.FinalProject.Exceptions;
using ASDP.FinalProject.Helpers;
using ASDP.FinalProject.Services;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Refit;
using System.Net;
using System.Text;
using System.Xml;
using static CSharpFunctionalExtensions.Result;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequestHandler : IRequestHandler<CreateSignPipelineRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly SigexApi _sigexApi;
        private readonly AdspContext _context;

        public CreateSignPipelineRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration, SigexApi sigexApi)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _sigexApi = sigexApi;
            _context = unitOfWork.GetContext();
        }
        public async Task<Result> Handle(CreateSignPipelineRequest request, CancellationToken cancellationToken)
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
                    .Where(x => x.Position.Permissions.Any(a => a.Permission.Code == PermissionCodes.SignDocuments))
                    .ToListAsync();

                var teamlid = await _context.Employees.FirstOrDefaultAsync(x => x.Position.Code == Constants.PositionCode.Teamlid && x.Iin == request.TeamleadIin);
                var director = await _context.Employees.FirstOrDefaultAsync(x => x.Position.Code == Constants.PositionCode.Director && x.Iin == request.DirectorIin);

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

                var data = new SigexRegisterNewDocumentRequest
                {
                    title = template.Name,
                    signType = "cms",
                    signature = request.CmsSign,
                    emailNotifications = new SigexEmailNotifications
                    {
                        to = new List<string>() { teamlid.Mail, director.Mail },
                        doNotAttachDocument = false,
                    },
                    settings = new SigexDocumentSettingsDto
                    {
                        @private = false,
                        signaturesLimit = 2,
                        forceArchive = true,
                        sequentialSignersRequirements = true,
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
                };

                var registerResult = await _sigexApi.RegisterNewDocument(data);

                
                if (registerResult.Content.DocumentId == null)
                {
                    throw new SigexException(registerResult.Content);
                }

                var saveResult = await _sigexApi.SaveDocument(registerResult.Content.DocumentId, new ByteArrayContent(signDocument.Content));

                if (saveResult.DocumentId == null)
                {
                    throw new SigexException(saveResult);
                }

                _context.SignPipeline.Add(signPipeline);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
            _unitOfWork.CommitTransaction();
            return Result.Success();

        }
    }
}
