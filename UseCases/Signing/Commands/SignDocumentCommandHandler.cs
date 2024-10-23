using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.DAL;
using CSharpFunctionalExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class SignDocumentCommandHandler : IRequestHandler<SignDocumentCommand, Result>
    {
        private readonly AdspContext _context;
        
        public SignDocumentCommandHandler(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        public async Task<Result> Handle(SignDocumentCommand request, CancellationToken cancellationToken)
        {
            var signPipeline = await _context.SignPipeline
                .Include(x => x.Signers)
                .ThenInclude(x => x.SignerEmployee.Position)
                .FirstAsync(x => x.Id == request.SignPipelineId);

            signPipeline.SignEmployee(request.IsSign, request.CreatorUserId);

            _context.Update(signPipeline);

            await _context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
