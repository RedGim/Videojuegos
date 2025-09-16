using lib_dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_repositorios.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Paises>? Paises { get; set; }
        DbSet<Categorias>? Categorias { get; set; }

        DbSet<Clasificaciones>? Clasificaciones { get; set; }
        DbSet<Plataformas>? Plataformas { get; set; }
        DbSet<Desarrolladores>? Desarrolladores { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}