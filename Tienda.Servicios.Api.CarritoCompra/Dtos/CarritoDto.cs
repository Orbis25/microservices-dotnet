namespace Tienda.Servicios.Api.CarritoCompra.Dtos
{
    public class CarritoDto
    {
        public Guid Id { get; set; }
        public DateTime? Fecha { get; set; }
        public List<CarritoDetalleDto> ListProductos { get; set; }
    }
}
