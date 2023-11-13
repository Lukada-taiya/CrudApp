using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using CrudApp.Application.DTOs;
using CrudApp.Application.Commands.Request;
using CrudApp.Application.Queries.Request;

namespace CrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : Controller
    {
        private readonly IMediator _mediator;

        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new GetAllBrandsRequest { });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto dto)
        {
            if (dto is null) return BadRequest();
            var response = await _mediator.Send(new CreateBrandCommand
            {
                CreateBrandDto = dto
            });
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto dto)
        {
            if (dto is null) return BadRequest();
            var response = await _mediator.Send(new UpdateBrandCommand {
            BrandDto = dto
            });
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrand(DeleteBrandDto dto)
        {
            if (dto is null) return BadRequest();
            var response = await _mediator.Send(new DeleteBrandCommand
            {
                BrandDto = dto
            });
            return Ok(response);
        }
    }
}
