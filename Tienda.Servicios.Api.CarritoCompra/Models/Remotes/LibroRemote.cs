namespace Tienda.Servicios.Api.CarritoCompra.Models.Remotes
{
    public class LibroRemote
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid AutorLibroID { get; set; }
    }
}
