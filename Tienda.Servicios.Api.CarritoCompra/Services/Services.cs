using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tienda.Servicios.Api.CarritoCompra.Dtos;
using Tienda.Servicios.Api.CarritoCompra.Models;
using Tienda.Servicios.Api.CarritoCompra.Models.Remotes;
using Tienda.Servicios.Api.CarritoCompra.Persistence;
using Tienda.Servicios.Api.CarritoCompra.Settings;

namespace Tienda.Servicios.Api.CarritoCompra.Services
{
    public interface IService
    {
        Task<CarritoSession?> CreateSesion(CarritoSession model);
        Task<CarritoDto?> Get(Guid id);
    }

    public class Service : IService
    {
        private readonly AppDbContext _dbContext;
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<Service> _logger;
        public Service(AppDbContext dbContext, IHttpClientFactory httpClient, ILogger<Service> logger)
        {
            _dbContext = dbContext;
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CarritoSession?> CreateSesion(CarritoSession model)
        {
            _dbContext.CarritoSessions.Add(model);

            if (await _dbContext.SaveChangesAsync() > 0)
                return model;

            return null;
        }

        private async Task<(bool isSuccess, LibroRemote? libro, string errorMessage)> GetLibro(Guid id)
        {
            try
            {
                var http = _httpClient.CreateClient(nameof(MicroServicios.Libros));
                var response = await http.GetAsync($"LibreriaMaterial/{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var result = JsonSerializer.Deserialize<LibroRemote>(content, options);
                    _logger.LogInformation("found:" + content);
                    return (true, result, string.Empty);
                }

                _logger.LogError(response?.ReasonPhrase);
                return (false, null, response?.ReasonPhrase ?? "error");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.GetBaseException().Message);
                return (false, null, ex.GetBaseException().Message);

            }
        }

        public async Task<CarritoDto?> Get(Guid id)
        {
            var result = await _dbContext.CarritoSessions
                .Include(d => d.CarritoSesionDetalles)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (result == null)
                return null;

            var list = new List<CarritoDetalleDto>();

            foreach (var item in result.CarritoSesionDetalles)
            {
                var (isSuccess, libro, errorMessage) = await GetLibro(item.ProductoSeleccionadoId);

                if (!isSuccess)
                {
                    _logger.LogError("Error:" + errorMessage);
                    throw new Exception(errorMessage);
                }

                if (libro != null)
                {
                    list.Add(new()
                    {
                        TituloLibro = libro.Titulo,
                        Fecha = libro.FechaPublicacion,
                        Id = libro.Id,
                    });
                }
            }

            return new()
            {
                Id = result.Id,
                Fecha = result.Fecha,
                ListProductos = list
            };
        }


    }
}
