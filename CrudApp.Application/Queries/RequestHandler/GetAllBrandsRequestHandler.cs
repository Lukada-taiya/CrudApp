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
    public class GetAllBrandsRequestHandler : IRequestHandler<GetAllBrandsRequest, IEnumerable<GetBrandDto>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Brand> _genericRepository;

        public GetAllBrandsRequestHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBrandDto>> Handle(GetAllBrandsRequest request, CancellationToken cancellationToken)
        {
            var sql = $"[dbo].[spcGetBrands]";
            var brands = await _genericRepository.GetAllAsync(sql);
            return _mapper.Map<IEnumerable<GetBrandDto>>(brands);
        }
    }
}
