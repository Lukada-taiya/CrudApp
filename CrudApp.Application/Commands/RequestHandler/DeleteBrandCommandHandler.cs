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
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand, int>
    {

        private readonly IGenericRepository<Brand> _genericRepository;
        private readonly IMapper _mapper;

        public DeleteBrandCommandHandler(IGenericRepository<Brand> genericRepository, IMapper mapper)
        {
            _mapper = mapper;
            _genericRepository = genericRepository;
        }
        public async Task<int> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {  
            FormattableString sql = $"[dbo].[spcDeleteBrand] @BrandIdpk = {request.BrandIdpk}";
            return await _genericRepository.Delete(sql);
        }
    }
}
