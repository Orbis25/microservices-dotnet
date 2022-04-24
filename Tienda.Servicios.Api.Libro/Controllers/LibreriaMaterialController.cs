using Microsoft.AspNetCore.Mvc;
using Tienda.Servicios.Api.Libro.Services;

namespace Tienda.Servicios.Api.Libro.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class LibreriaMaterialController : ControllerBase
    {
        private readonly IService _service;
        public LibreriaMaterialController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LibreriaMaterial model)
        {
            var result = await _service.Add(model);

            if (!result)
                return BadRequest(ModelState);

            return Created(nameof(Get), model);
        }


        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            var result = await _service.GetOne(id, cancellationToken);

            if (result == null)
                return NotFound(id);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return Ok(await _service.GetAll(cancellationToken));
        }
    }
}
