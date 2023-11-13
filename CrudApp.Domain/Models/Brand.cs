namespace CrudApp.Domain.Models
{
    public class Brand
    {
        public int BrandIdpk { get; set; }
        public string? Name { get; set; }
         
        public string? Category { get; set; }

        public int isActive { get; set; }

    }
}
