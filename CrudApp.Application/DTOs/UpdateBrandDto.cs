using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp.Application.DTOs
{
    public class UpdateBrandDto
    {
        public int BrandIdpk { get; set; }
        public string? Name { get; set; }

        public string? Category { get; set; }

        public int isActive { get; set; }
    }
}
