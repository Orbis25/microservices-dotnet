using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Tienda.Servicios.Api.Autor.Services.Autor
{
    public class AutorService : IAutorLibroService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IMapper _mapper;
        public AutorService(ApplicationDbContext context, IMapper mapper)
        {
            _ctx = context;
            _mapper = mapper;
        }

        public async Task<bool> Add(AutorLibro model, CancellationToken cancellationToken = default)
        {
            try
            {
                _ctx.AutorLibros.Add(model);
                return await _ctx.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException(ex.GetBaseException().Message);
            }
        }

        public Task<List<AutorLibroDto>> GetAll(CancellationToken cancellationToken = default)
        {
            return _ctx.AutorLibros.ProjectTo<AutorLibroDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }


        public async Task<AutorLibroDto> Get(Guid id, CancellationToken cancellationToken = default)
        {

            var result = await _ctx.AutorLibros.ProjectTo<AutorLibroDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (result == null)
                throw new InvalidOperationException("Not found");
            return result;

        }
    }
}
