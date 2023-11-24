using AutoMapper;
using CrudApp.Application.DTOs;
using CrudApp.Application.Queries.Request;
using CrudApp.Domain.Models;
using MediatR;

namespace CrudApp.Application.Queries.RequestHandler
{
    public class GetAllBrandsRequestHandler : GenericConstructor<Brand>, IRequestHandler<GetAllBrandsRequest, IEnumerable<GetBrandDto>>
    {
        
        public GetAllBrandsRequestHandler(IGenericRepository<Brand> genericRepository, IMapper mapper) : base(mapper, genericRepository)
        { 
        }

        public async Task<IEnumerable<GetBrandDto>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
        {
            var sql = $"[dbo].[spcGetBrands]";
            var brands = await _repository.GetAllAsync(sql);
            return _mapper.Map<IEnumerable<GetBrandDto>>(brands);
        }
    }
}
