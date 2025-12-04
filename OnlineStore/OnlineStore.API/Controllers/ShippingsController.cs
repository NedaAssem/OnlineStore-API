using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Interfaces;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.DTOs.Reviews;
using OnlineStore.Business.DTOs.Shippings;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingsController : ControllerBase
    {
        private readonly IShippingService _service;

        public ShippingsController(IShippingService service)
        {
            _service = service;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var item = await _service.GetShippingByOrderIdAsync(orderId);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateShippingDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
    }
}
