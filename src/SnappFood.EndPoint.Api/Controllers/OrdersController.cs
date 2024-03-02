using Microsoft.AspNetCore.Mvc;
using SnappFood.Application.Contract.Dtos.Orders;
using SnappFood.Application.Contract.Dtos.Products;
using SnappFood.Application.Contract.IServices;

namespace SnappFood.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Submit(SubmitOrderDto dto, CancellationToken cancellationToken)
        {
            await _orderService.SubmitAsync(dto, cancellationToken);
            return Created("Orders", null);
        }
    }
}
