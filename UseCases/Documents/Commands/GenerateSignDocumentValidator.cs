using ASDP.FinalProject.DAL.Models;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class GenerateSignDocumentCommandValidator : RequestValidatorBase<GenerateSignDocumentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenerateSignDocumentCommandValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Result> RequestValidateAsync(GenerateSignDocumentCommand request, CancellationToken cancellationToken)
        {
            var _context = _unitOfWork.GetContext();

            var employeeCreator = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.CreatorUserId);
            if (employeeCreator == null)
            {
                return Result.Failure("Сотрудник не найден");
            }

            var teamlead = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.TeamleadId);
            if (teamlead == null)
            {
                return Result.Failure("Тимлид не найден");
            }

            var director = await _context.Employees.FirstOrDefaultAsync(x => x.Id == request.DirectorId);
            if (director == null)
            {
                return Result.Failure("Директор не найден");
            }

            var template = await _context.Templates.FirstOrDefaultAsync(x => x.Id == request.TemplateId);
            if (template == null)
            {
                return Result.Failure("Шаблон не найден");
            }

            return Result.Success();
        }
    }
}
