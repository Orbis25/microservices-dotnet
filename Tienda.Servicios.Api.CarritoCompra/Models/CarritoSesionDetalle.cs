namespace Tienda.Servicios.Api.CarritoCompra.Models
{
    public class CarritoSesionDetalle
    {
        public Guid Id { get; set; }
        public DateTime? Fecha { get; set; }
        public Guid ProductoSeleccionadoId { get; set; }

        public Guid CarritoSessionId { get; set; }
        public CarritoSession? CarritoSession { get; set; }
    }
}
