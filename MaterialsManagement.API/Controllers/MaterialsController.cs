

using MaterialsManagement.BLL.Interfaces;
using MaterialsManagement.Model.Materials;
using MaterialsManagement.Model.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MaterialsManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialsController : ControllerBase
    {
        private readonly IMaterialService _materialService;

        public MaterialsController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FilterBase f)
        {
            var page = await _materialService.GetPageAsync(f);
            return Ok(page);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _materialService.FindByIdAsync(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> create([FromBody] Material mode)
        {
            var customer = await _materialService.SaveAsync(mode);
            return Ok(customer);
        }

        [HttpPut]
        public async Task<IActionResult> update([FromBody] Material mode)
        {
            var customer = await _materialService.UpdateAsync(mode);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _materialService.DeleteByCusIdAsync(id);
            return Ok(customer);
        }
    }
}
