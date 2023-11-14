using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CrudApp.Application.Commands.Request;
using CrudApp.Domain.Models;
using MediatR;

namespace CrudApp.Application.Commands.RequestHandler
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, ApiResponse>
    {

        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<ApiResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.BrandDto);
            FormattableString sql = $"[dbo].[spcUpdateBrand] @BrandIdpk = {request.BrandIdpk}, @Name = {brand.Name}, @Category = {brand.Category}, @IsActive = {brand.isActive}";

            var response = await _genericRepository.Update(sql);
            if (response > 0)
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
