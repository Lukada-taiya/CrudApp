using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application.DTOs;
using MediatR;

namespace CrudApp.Application.Commands.Request
{
    public class UpdateBrandCommand : IRequest<int>
    {
        public int BrandIdpk { get; set; }
        public UpdateBrandDto BrandDto { get; set; }
    }
}
