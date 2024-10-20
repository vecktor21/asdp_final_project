using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Documents.Commands
{
    public class AddTemplateRequestValidator : RequestValidatorBase<AddTemplateRequest>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AdspContext _context;

        public AddTemplateRequestValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Content).Must(x => x.Length > 0);
            RuleFor(x => x.Name).MinimumLength(0);
            _unitOfWork = unitOfWork;
            _context = unitOfWork.GetContext();
        }
        public override Task<Result> RequestValidateAsync(AddTemplateRequest request, CancellationToken cancellationToken)
        {
            string[] requiredTypes = new[] { "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };

            if (!requiredTypes.Contains(request.ContentType)){
                return Task.FromResult(Result.Failure("Тип файла должен быть документ Microsoft Word"));
            }

            return Task.FromResult(Result.Success());
        }
    }
}

