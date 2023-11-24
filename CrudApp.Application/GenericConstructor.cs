using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace CrudApp.Application
{
    public class GenericConstructor<TDto> where TDto : class
    {
        protected readonly IMapper _mapper;
        protected readonly IGenericRepository<TDto> _repository;

        public GenericConstructor(IMapper mapper, IGenericRepository<TDto> genericRepository)
        {
            _mapper = mapper;
            _repository = genericRepository;
        }
    }
}
