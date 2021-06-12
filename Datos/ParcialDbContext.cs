using System;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace Datos
{
    public class ParcialDbContext :DbContext
    {
        public ParcialDbContext(DbContextOptions options) : base(options)
        {
          
        }
          public DbSet<Persona> Personas { get; set; }
    }
}
