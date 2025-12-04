using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Interfaces;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.DTOs.Payments;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _service;

        public PaymentsController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            var item = await _service.GetPaymentsByOrderIdAsync(orderId);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
    }
}
