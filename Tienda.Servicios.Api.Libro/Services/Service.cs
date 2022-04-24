using Microsoft.EntityFrameworkCore;

namespace Tienda.Servicios.Api.Libro.Services
{

    public interface IService
    {
        Task<bool> Add(LibreriaMaterial model, CancellationToken cancellationToken = default);
        Task<IEnumerable<LibreriaMaterial>> GetAll(CancellationToken cancellationToken = default);

        Task<LibreriaMaterial?> GetOne(Guid id, CancellationToken cancellationToken = default);

    }

    public class Service : IService
    {
        private readonly ApplicationDbContext _dbContext;
        public Service(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Add(LibreriaMaterial model, CancellationToken cancellationToken = default)
        {
            try
            {
                _dbContext.LibreriaMaterials.Add(model);
                return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
            }
            catch (Exception ex)
            {
                throw new DbUpdateException(ex.GetBaseException().Message);
            }
        }

        public async Task<IEnumerable<LibreriaMaterial>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.LibreriaMaterials.ToListAsync(cancellationToken);
        }

        public async Task<LibreriaMaterial?> GetOne(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.LibreriaMaterials.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
