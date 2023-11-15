﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application.Commands.Request;
using CrudApp.Application;
using MediatR;
using CrudApp.Domain.Models;
using AutoMapper;
using FluentValidation;
using CrudApp.Application.Behaviours;

namespace CrudApp.Application.Commands.RequestHandler
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, ApiResponse>
    {
        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper; 

        public CreateBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper, IValidator validator)
        {
            _mapper = mapper;
            _genericRepository = genericRepository; 
        }
        public async Task<ApiResponse> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateBrandDtoValidator();
            var validationResult = validator.Validate(request.CreateBrandDto);

            if (!validationResult.IsValid) throw new Exception();

            var brand = _mapper.Map<Brand>(request.CreateBrandDto);
            FormattableString sqlCommand = $"[dbo].[spcCreateBrand] @Name = {brand.Name}, @Category= {brand.Category}, @IsActive={brand.isActive}";
            
            var response = await _genericRepository.Add(sqlCommand);

            if(response > 0)
            {
                return new ApiResponse()
                {
                    isStatus = true,
                    Message = "Record has been saved successfully"
                };
            }

            return new ApiResponse()
            {
                isStatus = false,
                Message = "Record was unable to save"
            };
        }
    }
}
