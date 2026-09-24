using GestionLibreria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Infrastructure.Persistence
{
    public class GestionLibreriaDbContext : DbContext
    {
        public GestionLibreriaDbContext(DbContextOptions<GestionLibreriaDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Client> Clients => Set<Client>();

    }
}
