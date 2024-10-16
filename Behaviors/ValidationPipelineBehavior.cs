using ASDP.FinalProject.Exceptions;
using ASDP.FinalProject.Validators;
using MediatR;
using Serilog;

namespace ASDP.FinalProject.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IResult
    {
        private readonly IEnumerable<IRequestValidator<TRequest>> _validators;
        private readonly Serilog.ILogger _logger;

        public ValidationPipelineBehavior(IEnumerable<IRequestValidator<TRequest>> validators, Serilog.ILogger logger)
        {
            _validators = validators;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            foreach (var validator in _validators)
            {
                var validateFluentRulesResult = await validator.RequestValidateAsync(request, cancellationToken);
                if (validateFluentRulesResult.IsFailure)
                {
                    _logger.Warning(validateFluentRulesResult.Error);
                    throw new AsdpException(validateFluentRulesResult);
                }
            }

            return await next();
        }
    }
}
