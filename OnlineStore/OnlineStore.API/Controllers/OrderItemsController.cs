using Microsoft.AspNetCore.Mvc;
using OnlineStore.Business.Interfaces;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.DTOs.OrderItems;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet("order/{orderId}")]
        public async Task<IActionResult> GetByOrder(int orderId)
        {
            return Ok(await _service.GetItemsByOrderIdAsync(orderId));
        }

      
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    return await _service.DeleteAsync(id) ? NoContent() : NotFound();
        //}
    }
}
