namespace Tienda.Servicios.Api.Autor.Modelos
{
    public class GradoAcademico
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string CentroAcademico { get; set; }
        public DateTime? FechaGrado { get; set; }
        public Guid  AutorLibroId { get; set; }
        public AutorLibro AutorLibro { get; set; }
        public Guid GradoAcademicoId { get; set; }
    }
}
