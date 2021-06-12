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
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Inscrito> Inscritos { get; set; }
        public DbSet<CursoInscrito> CursoInscritos { get; set; }
    }
}
