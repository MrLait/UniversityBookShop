﻿using FluentValidation;
using UniversityBookShop.Application.Common.Constants;

namespace UniversityBookShop.Application.Common.Models.AbstractValidators
{
    public abstract class AbstractFacultyCommandValidator<T> : AbstractValidator<T> where T : FacultyCommandBase
    {
        public AbstractFacultyCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .MaximumLength(150).WithMessage(ServiceErrorConstants.MustBeLessThan);
            RuleFor(x => x.UniversityId)
                .NotEmpty().WithMessage(ServiceErrorConstants.FieldNotEmpty)
                .GreaterThan(0).WithMessage(ServiceErrorConstants.GreaterThanZero);
        }
    }
}