using Microsoft.EntityFrameworkCore;
using MiPrimeraAPI.Models;

namespace MiPrimeraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarea> Tareas { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

    }
}
