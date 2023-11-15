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
            RuleFor(p => p.isActive).NotEmpty().WithMessage("{PropertyName} is required")
                .LessThan(2).WithMessage("{PropertyName} must be between 0 and 1")
                .GreaterThan(2).WithMessage("{PropertyName} must be between 0 and 1");


        }
    }

    public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
    {

        public UpdateBrandDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.isActive).NotEmpty().WithMessage("{PropertyName} is required")
                .LessThan(2).WithMessage("{PropertyName} must be between 0 and 1")
                .GreaterThan(2).WithMessage("{PropertyName} must be between 0 and 1");


        }
    }

    public class GetBrandDtoValidator : AbstractValidator<GetBrandDto>
    {

        public GetBrandDtoValidator()
        {
            RuleFor(p => p.BrandIdpk).NotEmpty();
            RuleFor(p => p.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required");

            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(p => p.isActive).NotEmpty().WithMessage("{PropertyName} is required")
                .LessThan(2).WithMessage("{PropertyName} must be between 0 and 1")
                .GreaterThan(2).WithMessage("{PropertyName} must be between 0 and 1");
        }
    }
}
