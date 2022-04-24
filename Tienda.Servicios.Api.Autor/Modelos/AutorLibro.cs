using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Tienda.Servicios.Api.Autor.Modelos
{
    public class AutorLibroCreateDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNamcimiento { get; set; }

        public static implicit operator AutorLibro(AutorLibroCreateDto autorLibro)
        {
            return new()
            {
                Apellido = autorLibro.Apellido,
                FechaNamcimiento = autorLibro.FechaNamcimiento,
                Nombre = autorLibro.Nombre,
            };
        }
    }

    public class AutorLibroDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNamcimiento { get; set; }

    
    }

    public class AutorLibroValidation : AbstractValidator<AutorLibroCreateDto>
    {
        public AutorLibroValidation()
        {
            RuleFor(x => x.Nombre).NotEmpty();
            RuleFor(x => x.Apellido).NotEmpty();
        }
    }

    public class AutorLibro
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime? FechaNamcimiento { get; set; }

        public ICollection<GradoAcademico> GradoAcademicos { get; set; }
        public Guid AutorLibroGuid { get; set; } = Guid.NewGuid();


    }
}
