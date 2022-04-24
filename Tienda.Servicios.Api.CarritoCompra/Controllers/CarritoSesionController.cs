using Microsoft.AspNetCore.Mvc;
using Tienda.Servicios.Api.CarritoCompra.Models;
using Tienda.Servicios.Api.CarritoCompra.Services;

namespace Tienda.Servicios.Api.CarritoCompra.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoSesionController : ControllerBase
    {
        private readonly IService _service;
        public CarritoSesionController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarritoSession model)
        {
            var result = await _service.CreateSesion(model);
            
            if (result == null)
                return BadRequest("Invalid saving data...");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _service.Get(id));
        }
    }
}
