using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.Model.Customers;
using MaterialsManagement.Model.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaterialsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterBase f)
        {
            var page = await _customerService.GetPageAsync(f);
            return Ok(page);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _customerService.FindByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] Customer mode)
        {
            var customer = await _customerService.SaveAsync(mode);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody] Customer mode)
        {
            var customer = await _customerService.UpdateAsync(mode);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.DeleteByCusIdAsync(id);
            return Ok(customer);
        }
    }
}
