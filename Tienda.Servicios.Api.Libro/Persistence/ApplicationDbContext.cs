using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.Libro.Models;

namespace Tienda.Servicios.Api.Libro.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }

        public DbSet<LibreriaMaterial> LibreriaMaterials { get; set; }
    }
}
