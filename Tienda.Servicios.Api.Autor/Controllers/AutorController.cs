using Microsoft.AspNetCore.Mvc;
using Tienda.Servicios.Api.Autor.Services;

namespace Tienda.Servicios.Api.Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorLibroService _autorLibroService;
        public AutorController(IAutorLibroService autorLibroService)
        {
            _autorLibroService = autorLibroService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(AutorLibroCreateDto model)
        {
            var result = await _autorLibroService.Add(model);

            if (!result)
                return BadRequest("No se creo el autor");

            return Created(nameof(Get), model);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _autorLibroService.GetAll(cancellationToken));
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await _autorLibroService.Get(id));
        }
    }
}
