using Api01.Application.DTOs;
using Api01.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api01.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] ProductDTO productDTO)
        {
            var result = await _service.CreateAsync(productDTO);
            if (result.IsSucess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        } 
    }
}
