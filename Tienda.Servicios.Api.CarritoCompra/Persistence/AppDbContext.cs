using Microsoft.EntityFrameworkCore;
using Tienda.Servicios.Api.CarritoCompra.Models;

namespace Tienda.Servicios.Api.CarritoCompra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            if (Database.GetPendingMigrations().Any())
            {
                Database.Migrate();
            }
        }

        public DbSet<CarritoSession> CarritoSessions { get; set; }
        public DbSet<CarritoSesionDetalle> CarritoSesionDetalles { get; set; }
    }
}
