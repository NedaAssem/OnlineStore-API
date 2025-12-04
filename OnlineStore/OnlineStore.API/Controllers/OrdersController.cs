using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Interfaces;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.DTOs.Orders;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllOrdersAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _service.GetOrderByIdAsync(id);
            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto dto)
        {
            var item = await _service.CreateOrderAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = item.OrderId }, item);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, UpdateOrderStatusDto dto)
        //{
        //    var item = await _service.UpdateOrderStatusAsync(id, dto);
        //    return item == null ? NotFound() : Ok(item);
        //}

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return await _service.DeleteOrderAsync(id) ? NoContent() : NotFound();
        //}
    }
}
