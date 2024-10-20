using ASDP.FinalProject.DAL;
using ASDP.FinalProject.DAL.Repositories;
using ASDP.FinalProject.UseCases.Employees.Dtos;
using ASDP.FinalProject.Validators;
using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ASDP.FinalProject.UseCases.Employees.Commands
{
    public class RegisterEmployeeRequestValidator : RequestValidatorBase<RegisterEmployeeRequest>
    {
        private AdspContext _context;
        public RegisterEmployeeRequestValidator(IUnitOfWork unitOfWork)
        {
            _context = unitOfWork.GetContext();
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.SurName).NotNull();
            RuleFor(x => x.Mail).NotNull().EmailAddress();
            RuleFor(x => x.Password).NotNull();
            RuleFor(x => x.RepeatPassword).NotNull();
            RuleFor(x => x.IdentityNumber).NotNull();
            RuleFor(x => x.IdentityIssueDate).NotNull();
            RuleFor(x => x.IdentityIssuer).NotNull();
            RuleFor(x => x.Iin).NotNull().Length(12);
            RuleFor(x => x.PositionCode).NotNull();
        }

        public override Task<Result> RequestValidateAsync(RegisterEmployeeRequest request, CancellationToken cancellationToken)
        {
            var validationResult = this.Validate(request);

            if (!validationResult.IsValid)
            {
                var res = Result.Failure(validationResult.Errors.ToString());
                return Task.FromResult(res);
            }

            var existingEmployeeByMail = _context.Employees.FirstOrDefault(x => x.Mail == request.Mail);
            if(existingEmployeeByMail != null)
            {
                return Task.FromResult(Result.Failure("Сотрудник с такой почтой уже существует"));
            }
            var existingEmployeeByIin = _context.Employees.FirstOrDefault(x => x.Iin == request.Iin);
            if (existingEmployeeByIin != null)
            {
                return Task.FromResult(Result.Failure("Сотрудник с таким иином уже существует"));
            }
            return Task.FromResult(Result.Success());
        }
    }
}
