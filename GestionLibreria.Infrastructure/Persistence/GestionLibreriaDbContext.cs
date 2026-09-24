using GestionLibreria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestionLibreria.Infrastructure.Persistence
{
    public class GestionLibreriaDbContext : DbContext
    {
        public GestionLibreriaDbContext(DbContextOptions<GestionLibreriaDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Product> Products => Set<Product>();
    }
}
