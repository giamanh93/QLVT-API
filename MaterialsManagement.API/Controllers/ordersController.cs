
using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.Model.Orders;
using MaterialsManagement.Model.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaterialsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public ordersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterBase f)
        {
            var page = await _orderService.GetPageAsync(f);
            return Ok(page);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _orderService.FindByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] Order mode)
        {
            var customer = await _orderService.SaveAsync(mode);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody] Order mode)
        {
            var customer = await _orderService.UpdateAsync(mode);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _orderService.DeleteByCusIdAsync(id);
            return Ok(customer);
        }
    }
}
