using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using AutoMapper;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequestHandler : IRequestHandler<CreateSignPipelineRequest, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AdspContext _context;

        public CreateSignPipelineRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
            _context = unitOfWork.GetContext();
        }
        public async Task<Result> Handle(CreateSignPipelineRequest request, CancellationToken cancellationToken)
        {
            _unitOfWork.BeginTransaction(); 

            try
            {
                var creator = await _context.Employees.SingleAsync(x => x.Id == request.UserId);

                byte[] content;

                using (var ms = new MemoryStream())
                {
                    request.GeneratedDocument.CopyTo(ms);
                    content = ms.ToArray();
                }

                var signPipeline = new SignPipeline(creator, request.SigexSidnId, content, request.GeneratedDocument.Name, request.SigexDocumentId);


                var teamlid = await _context.Employees.FirstAsync(x => x.Position.Code == Constants.PositionCode.Teamlid && x.Iin == request.TeamleadIin);
                var director = await _context.Employees.FirstAsync(x => x.Position.Code == Constants.PositionCode.Director && x.Iin == request.DirectorIin);

                signPipeline.AddSigner(teamlid, 1);
                signPipeline.AddSigner(director, 2);

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
