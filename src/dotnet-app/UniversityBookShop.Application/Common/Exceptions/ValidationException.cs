using FluentValidation.Results;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(): base(ServiceErrorConstants.ValidationError)
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures): this()
        {
            var failureGroups = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

            foreach (var failureGroup in failureGroups)
            {
                var propertyName = failureGroup.Key;
                var propertyFailures = failureGroup.ToArray();

                Errors.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
