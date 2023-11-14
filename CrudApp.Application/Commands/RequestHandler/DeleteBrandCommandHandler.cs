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
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, ApiResponse>
    {

        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<ApiResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {  
            FormattableString sql = $"[dbo].[spcDeleteBrand] @BrandIdpk = {request.BrandIdpk}";
            var response = await _genericRepository.Delete(sql);
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
