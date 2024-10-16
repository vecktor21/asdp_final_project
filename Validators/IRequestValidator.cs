using CSharpFunctionalExtensions;

namespace ASDP.FinalProject.Validators
{
    public interface IRequestValidator<in TRequest>
    {
        Task<Result> RequestValidateAsync(TRequest request, CancellationToken cancellationToken);
    }
}
