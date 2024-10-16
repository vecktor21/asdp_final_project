using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Signing.Commands
{
    public class CreateSignPipelineRequestValidator : RequestValidatorBase<CreateSignPipelineRequest>
    {
        private AdspContext _context {  get; set; }
        public CreateSignPipelineRequestValidator(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
        }
        public override async Task<Result> RequestValidateAsync(CreateSignPipelineRequest request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x=> x.Id == request.UserId);
            if (employee == null)
            {
                return Result.Failure($"Сотрудник с Id {request.UserId} не найден");
            }

            var fileType = request.GeneratedDocument.Name.Split(".")[request.GeneratedDocument.Name.Length - 1];
            if(fileType != "pdf")
            {
                return Result.Failure($"Не поддерживаемый тип документа");
            }

            var template = _context.Templates.Where(x => x.Id == request.TemplateId).FirstOrDefault();
            if (template != null)
            {
                return Result.Failure($"Неподдерживаемый шаблон");
            }

            return Result.Success();

        }
    }
}
