using ASDP.FinalProject.Constants;
using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class SignDocumentCommandValidator : RequestValidatorBase<SignDocumentCommand>
    {
        private readonly AdspContext _context;
        private List<SignPipelineStatus> _pipelineStatusesInProcess = new()
        {
            SignPipelineStatus.Created,
            SignPipelineStatus.InProcess,
            SignPipelineStatus.SignedByTeamlid,
        };

        public SignDocumentCommandValidator(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
            RuleFor(x => x.SignPipelineId).NotEmpty();
            RuleFor(x=>x.CreatorUserId).NotEmpty();
        }
        public override async Task<Result> RequestValidateAsync(SignDocumentCommand request, CancellationToken cancellationToken)
        {
            var signPipeline = await _context.SignPipeline
                .Include(x=>x.Signers)
                .ThenInclude(x=>x.SignerEmployee)
                .FirstOrDefaultAsync(x=> x.Id==request.SignPipelineId);


            if (signPipeline==null)
            {
                return Result.Failure("Очередь подписания не найдена");
            }

            if(!_pipelineStatusesInProcess.Contains(signPipeline.Status))
            {
                return Result.Failure("Очередь подписания завершена");
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(x=>x.Id==request.CreatorUserId);
            if (employee==null)
            {
                return Result.Failure("Сотрудник не найден");
            }

            var employeeToSign = signPipeline.Signers
                .OrderBy(x => x.Order)
                .FirstOrDefault(x => !x.IsSigned)
                ?.SignerEmployee;

            if(employeeToSign == null)
            {
                return Result.Failure("Очередь подписания завершена");
            }

            if(employeeToSign.Id !=request.CreatorUserId)
            {
                return Result.Failure("Сейчас не ваша очередь подписать");
            }

            return Result.Success();
        }
    }
}
