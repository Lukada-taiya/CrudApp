using Microsoft.EntityFrameworkCore;
using CrudApp.Domain.Models;
using CrudApp.Application.DTOs;

namespace CrudApp.Infrastructure.Data;

public class BrandContext : DbContext
{
    public BrandContext(DbContextOptions opt) : base(opt)
    {

    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<GetBrandDto> GetBrandDtos { get; set; }
    public DbSet<UpdateBrandDto> UpdateBrandDtos { get; set; }
    public DbSet<CreateBrandDto> CreateBrandDtos { get; set; } 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<GetBrandDto>().HasNoKey();
        modelBuilder.Entity<CreateBrandDto>().HasNoKey(); 
        modelBuilder.Entity<UpdateBrandDto>().HasNoKey();
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandIdpk);
        });
    }
}
