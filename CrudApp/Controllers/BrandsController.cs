using Microsoft.AspNetCore.Mvc; 
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
        [Route("GetAllBrands")]
        public async Task<IActionResult> GetAllBrands()
        {
            var response = await _mediator.Send(new GetAllBrandsRequest { });
            return Ok(response);
        }

        [HttpGet]
        [Route("GetBrandById")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var response = await _mediator.Send(new GetBrandByIdRequest {
                BrandIdpk = id
            });
            return Ok(response);
        }

        [HttpPost]
        [Route("AddBrand")]
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
        [Route("UpdateBrand")] 
        public async Task<IActionResult> UpdateBrand(int id, UpdateBrandDto dto)
        {
            if (dto is null) return BadRequest();
            var response = await _mediator.Send(new UpdateBrandCommand {
                BrandIdpk = id,
            BrandDto = dto
            }) ;
            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteBrand")]
        public async Task<IActionResult> DeleteBrand(int id)
        { 
            var response = await _mediator.Send(new DeleteBrandCommand
            {
                BrandIdpk = id
            });
            return Ok(response);
        }
    }
}
