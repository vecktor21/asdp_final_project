using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequestValidator : RequestValidatorBase<CreateSignPipelineRequest>
    {
        private AdspContext _context {  get; set; }
        public CreateSignPipelineRequestValidator(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
            RuleFor(x => x.TeamleadIin).Length(12);
            RuleFor(x => x.DirectorIin).Length(12);
            RuleFor(x => x.SigexDocumentId).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(x => x.SigexSignId).NotNull().NotEqual(0);
        }
        public override async Task<Result> RequestValidateAsync(CreateSignPipelineRequest request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=> x.Id == request.UserId);
            if (employee == null)
            {
                return Result.Failure($"Сотрудник с Id {request.UserId} не найден");
            }

            var teamlid = await _context.Employees.FirstOrDefaultAsync(x => x.Position.Code == Constants.PositionCode.Teamlid && x.Iin == request.TeamleadIin);
            if (teamlid == null)
            {
                return Result.Failure($"Тимлид {request.TeamleadIin} не найден");
            }
            var director = await _context.Employees.FirstOrDefaultAsync(x => x.Position.Code == Constants.PositionCode.Director && x.Iin == request.DirectorIin);
            if (director == null)
            {
                return Result.Failure($"Директор {request.DirectorIin} не найден");
            }

            var fileType = request.GeneratedDocument.ContentType;
            if(fileType != "application/pdf")
            {
                return Result.Failure($"Не поддерживаемый тип документа");
            }

            return Result.Success();

        }
    }
}
