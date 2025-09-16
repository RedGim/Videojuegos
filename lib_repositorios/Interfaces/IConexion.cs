using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Paises>? Paises { get; set; }

        DbSet<Bibliotecas>? Bibliotecas { get; set; }
        DbSet<Resenas>? Resenas { get; set; }
        DbSet<CarritoCompras>? CarritoCompras { get; set; }
        DbSet<CarritoDetalles>? CarritoDetalles { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Categorias>? Categorias { get; set; }

        DbSet<Clasificaciones>? Clasificaciones { get; set; }
        DbSet<Plataformas>? Plataformas { get; set; }
        DbSet<Desarrolladores>? Desarrolladores { get; set; }
        public DbSet<Usuarios>? Usuarios { get; set; }
        public DbSet<Perfiles>? Perfiles { get; set; }
        public DbSet<Videojuegos>? Videojuegos { get; set; }
        public DbSet<Usuarios_roles>? Usuarios_roles { get; set; }
        DbSet<Roles>? Roles { get; set; }
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}