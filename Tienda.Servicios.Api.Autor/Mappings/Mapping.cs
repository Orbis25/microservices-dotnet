using AutoMapper;
 
namespace Tienda.Servicios.Api.Autor.Mappings
{
    public class Mapping : Profile
    {
        public Mapping() => CreateMap<AutorLibro, AutorLibroDto>().ReverseMap();
    }
}
