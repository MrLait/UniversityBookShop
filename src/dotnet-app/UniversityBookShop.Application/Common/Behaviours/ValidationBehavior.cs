using FluentValidation;
using MediatR;
using ValidationException =  UniversityBookShop.Application.Common.Exceptions.ValidationException;

namespace UniversityBookShop.Application.Common.Behaviours
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));
                var errors = validationResults
                    .Where(validationResults => !validationResults.IsValid)
                    .SelectMany(validationResults => validationResults.Errors);

                if (errors.Any())
                {
                    throw new ValidationException(errors);
                }
            }

            return await next();
        }
    }
}
