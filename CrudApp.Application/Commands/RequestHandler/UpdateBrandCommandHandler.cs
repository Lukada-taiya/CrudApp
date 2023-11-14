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
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, int>
    {

        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public UpdateBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<int> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.BrandDto);
            FormattableString sql = $"[dbo].[spcUpdateBrand] @BrandIdpk = {request.BrandIdpk}, @Name = {brand.Name}, @Category = {brand.Category}, @IsActive = {brand.isActive}";

            return await _genericRepository.Update(sql);
        }
    }
}
