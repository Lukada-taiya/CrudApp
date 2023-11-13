using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application.Commands.Request;
using CrudApp.Application;
using MediatR;
using CrudApp.Domain.Models;
using AutoMapper;

namespace CrudApp.Application.Commands.RequestHandler
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
    {
        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public CreateBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = _mapper.Map<Brand>(request.CreateBrandDto);
            FormattableString sqlCommand = $"[dbo].[spcCreateBrand] @Name = {brand.Name}, @Category= {brand.Category}, @IsActive={brand.isActive}";
            
            return await _genericRepository.Add(sqlCommand);
        }
    }
}
