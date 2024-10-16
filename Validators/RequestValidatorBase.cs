using CSharpFunctionalExtensions;
using FluentValidation;
using MediatR;

namespace ASDP.FinalProject.Validators
{
    public abstract class RequestValidatorBase<TRequest> : AbstractValidator<TRequest>, IRequestValidator<TRequest>
    {
        public abstract Task<Result> RequestValidateAsync(TRequest request, CancellationToken cancellationToken);
        public async Task<Result> RequestValidateFluentRulesAsync(TRequest request, CancellationToken cancellationToken)
        {
            var fluentValidationResult = await base.ValidateAsync(request, cancellationToken);
            if (!fluentValidationResult.IsValid)
            {
                var errorText = string.Join(Environment.NewLine, fluentValidationResult.Errors.Select(x => $"{x.ErrorCode} - {x.ErrorMessage}"));
                return Result.Failure(errorText);
            }
            return Result.Success();

        }

    }
}
