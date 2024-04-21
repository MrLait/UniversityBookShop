using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Cqrs.Auths.Queries.Get
{
    public class LoginByUserNameAndPasswordQueryValidator : AbstractValidator<LoginByUserNameAndPasswordQuery>
    {
        public LoginByUserNameAndPasswordQueryValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty);
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ApplicationConstants.Service.Error.FieldNotEmpty);
        }
    }
}
