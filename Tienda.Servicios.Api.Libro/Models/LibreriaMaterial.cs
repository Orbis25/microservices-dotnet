using FluentValidation;

namespace Tienda.Servicios.Api.Libro.Models
{
    public class LibreriaMaterial
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public Guid AutorLibroID { get; set; }
    }

    public class LibreriaMaterialValidations : AbstractValidator<LibreriaMaterial>
    {
        public LibreriaMaterialValidations()
        {
            RuleFor(x => x.Titulo).NotNull().NotEmpty();
            RuleFor(x => x.FechaPublicacion).NotNull().NotEmpty();
            RuleFor(x => x.AutorLibroID).NotNull().NotEmpty();
        }
    }
}
