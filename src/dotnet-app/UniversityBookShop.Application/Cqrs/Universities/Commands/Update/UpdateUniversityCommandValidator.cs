using FluentValidation;
using UniversityBookShop.Application.Common.Constants;
using UniversityBookShop.Application.Common.Models.AbstractValidators;

namespace UniversityBookShop.Application.Cqrs.Universities.Commands.Update
{
    public class UpdateUniversityCommandValidator: AbstractUniversityCommandValidator<UpdateUniversityCommand>
    {
        public UpdateUniversityCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}
