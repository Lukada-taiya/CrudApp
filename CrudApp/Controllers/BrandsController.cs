using CrudApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly BrandContext _brandContext;

        public BrandsController(BrandContext brandContext)
        {
            _brandContext = brandContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetAllBrands()
        {
            if (_brandContext.Brands == null) return NotFound();

            var brands = await _brandContext.Brands.ToListAsync();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrand(int id)
        {
            if (_brandContext.Brands == null) return NotFound();

            var brand = await _brandContext.Brands.FindAsync(id);
            return Ok(brand);
        }

        [HttpPost]
        public async Task<ActionResult<Brand>> PostBrand(Brand brand)
        {
            _brandContext.Brands.Add(brand);
            await _brandContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrand), new { id = brand.BrandIdpk }, brand);
        }

        [HttpPut]
        public async Task<ActionResult> PutBrand(int id, Brand brand)
        {
            if(id != brand.BrandIdpk) return BadRequest();
            _brandContext.Entry(brand).State = EntityState.Modified;

            try
            {
                await _brandContext.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException)
            {
                if (!BrandAvailable(id)) return NotFound();
                throw;
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBrand(int id)
        {
            if (_brandContext.Brands == null) return NotFound();
            var brand = await _brandContext.Brands.FindAsync(id);
            if(brand == null) return NotFound();
            _brandContext.Brands.Remove(brand);
            await _brandContext.SaveChangesAsync();

            return Ok();
        }
        
        private bool BrandAvailable(int id)
        {
            return (_brandContext.Brands?.Any(x => x.BrandIdpk == id)).GetValueOrDefault();
        }
    }
}
