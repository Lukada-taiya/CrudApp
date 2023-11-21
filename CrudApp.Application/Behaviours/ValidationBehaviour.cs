using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application.DTOs;
using FluentValidation;

namespace CrudApp.Application.Behaviours
{
    public class CreateBrandDtoValidator: AbstractValidator<CreateBrandDto>
    {

        public CreateBrandDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.isActive)
                .LessThanOrEqualTo(1).WithMessage("{PropertyName} must be either 0 or 1")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be either 0 or 1");
        }
    }

    public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
    {

        public UpdateBrandDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.isActive).LessThanOrEqualTo(1).WithMessage("{PropertyName} must be either 0 or 1")
                .GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be either 0 or 1");
        }
    }
}
