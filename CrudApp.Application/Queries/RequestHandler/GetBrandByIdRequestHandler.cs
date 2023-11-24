using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CrudApp.Application.DTOs;
using CrudApp.Application.Queries.Request;
using CrudApp.Domain.Models;
using MediatR;

namespace CrudApp.Application.Queries.RequestHandler
{
    public class GetBrandByIdRequestHandler : GenericConstructor<Brand>, IRequestHandler<GetBrandByIdRequest, GetBrandDto>
    { 

        public GetBrandByIdRequestHandler(IMapper mapper, IGenericRepository<Brand> genericRepository) : base(mapper, genericRepository)
        { 
        }
        public async Task<GetBrandDto> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            FormattableString sql = $"[dbo].[spcGetBrandById] @BrandIdpk = {request.BrandIdpk}";
            var brand = await _repository.Get(sql);
            return _mapper.Map<GetBrandDto>(brand);
        }
    }
}
