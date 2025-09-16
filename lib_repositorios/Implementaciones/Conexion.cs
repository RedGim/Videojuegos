using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Paises>? Paises { get; set; }

        public DbSet<Bibliotecas>? Bibliotecas { get; set; }
        public DbSet<Resenas>? Resenas { get; set; }
        public DbSet<CarritoCompras>? CarritoCompras { get; set; }
        public DbSet<CarritoDetalles>? CarritoDetalles { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Categorias>? Categorias { get; set; }
        public DbSet<Clasificaciones>? Clasificaciones { get; set; }
        public DbSet<Plataformas>? Plataformas { get; set; }
        public DbSet<Desarrolladores>? Desarrolladores { get; set; }
        public DbSet<Roles>? Roles { get; set; }
    }
}