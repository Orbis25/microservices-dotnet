namespace Tienda.Servicios.Api.CarritoCompra.Models
{
    public class CarritoSession
    {
        public Guid Id { get; set; }
        public DateTime? Fecha { get; set; }
        public ICollection<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }
    }
}
