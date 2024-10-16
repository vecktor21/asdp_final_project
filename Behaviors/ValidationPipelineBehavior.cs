using ASDP.FinalProject.Exceptions;
using ASDP.FinalProject.UseCases.Employees.Commands;
using ASDP.FinalProject.UseCases.Signing.Commands;
using ASDP.FinalProject.Validators;
using FluentValidation;
using MediatR;
using Serilog;

namespace ASDP.FinalProject.Behaviors
{
    public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
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
                    throw new AsdpException(validateFluentRulesResult);
                }

                var requestValidateResult = await validator.RequestValidateAsync(request, cancellationToken);
                if (requestValidateResult.IsFailure)
                {
                    throw new AsdpException(requestValidateResult);
                }
            }

            return await next();
        }
    }

    /*public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IRequestValidator<TRequest>> _asyncValidators;
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly Serilog.ILogger _logger;

        public ValidationBehaviour(IEnumerable<IRequestValidator<TRequest>> asyncValidators,
            IEnumerable<IValidator<TRequest>> validators, Serilog.ILogger logger)
        {
            _asyncValidators = asyncValidators;
            _validators = validators;
            _logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_asyncValidators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_asyncValidators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new ValidationException(failures);
            }

            foreach (var validator in _asyncValidators)
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
    }*/
}
