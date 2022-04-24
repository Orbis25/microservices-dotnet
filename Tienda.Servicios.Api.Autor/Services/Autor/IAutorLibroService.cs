using Tienda.Servicios.Api.Autor.Modelos;

namespace Tienda.Servicios.Api.Autor.Services
{
    public interface IAutorLibroService
    {
        Task<bool> Add(AutorLibro model, CancellationToken cancellationToken = default);
        Task<List<AutorLibroDto>> GetAll(CancellationToken cancellationToken = default);
        Task<AutorLibroDto> Get(Guid id, CancellationToken cancellationToken = default);
    }
}
