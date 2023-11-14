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
    public class GetBrandByIdRequestHandler : IRequestHandler<GetBrandByIdRequest, GetBrandDto>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Brand> _genericRepository;

        public GetBrandByIdRequestHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }
        public async Task<GetBrandDto> Handle(GetBrandByIdRequest request, CancellationToken cancellationToken)
        {
            FormattableString sql = $"[dbo].[spcGetBrandById] @BrandIdpk = {request.BrandIdpk}";
            var brand = await _genericRepository.Get(sql);
            return _mapper.Map<GetBrandDto>(brand);
        }
    }
}
