using Microsoft.AspNetCore.Mvc;
using SnappFood.Application.Contract.Dtos.Products;
using SnappFood.Application.Contract.IServices;

namespace SnappFood.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var product = await _productService.GetAsync(id, cancellationToken);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AddProductDto dto, CancellationToken cancellationToken)
        {
            await _productService.CreateAsync(dto, cancellationToken);
            return Created("Products", null);
        }

        [HttpPatch]
        public async Task<IActionResult> ChangeInventoryCountAsync(ChangeInventoryCountDto dto, CancellationToken cancellationToken)
        {
            await _productService.ChangeInventoryCountAsync(dto, cancellationToken);
            return NoContent();
        }
    }
}
