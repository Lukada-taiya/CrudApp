using Microsoft.EntityFrameworkCore;

namespace CrudApp.Models
{
    public class BrandContext : DbContext
    {
        public BrandContext(DbContextOptions opt) : base(opt) 
        {
            
        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.BrandIdpk);
            });
        }
    }
}
