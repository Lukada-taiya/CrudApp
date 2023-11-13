using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrudApp.Application.DTOs;
using MediatR;

namespace CrudApp.Application.Queries.Request
{
    public class GetAllBrandsRequest : IRequest<IEnumerable<GetBrandDto>>
    {
    }
}
