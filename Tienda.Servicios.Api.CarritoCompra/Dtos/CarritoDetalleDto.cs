namespace Tienda.Servicios.Api.CarritoCompra.Dtos
{
    public class CarritoDetalleDto
    {
        public Guid Id { get; set; }
        public string TituloLibro { get; set; }
        public string AutorLibro { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
