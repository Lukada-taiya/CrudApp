using CrudApp.Application.Behaviours;
using CrudApp.Application.DTOs;
using FluentValidation;

namespace CrudApp
{
    public static class ValidationServiceExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<GetBrandDto>, GetBrandDtoValidator>();
            services.AddScoped<IValidator<CreateBrandDto>, CreateBrandDtoValidator>();
            services.AddScoped<IValidator<UpdateBrandDto>, UpdateBrandDtoValidator>();
            return services;
        }
    }
}
