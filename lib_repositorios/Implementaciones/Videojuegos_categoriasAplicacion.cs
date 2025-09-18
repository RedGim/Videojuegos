using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Videojuegos_categoriasAplicacion: IVideojuegos_categoriasAplicacion
    {
        private IConexion? IConexion = null;

        public Videojuegos_categoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Videojuegos_categorias? Borrar(Videojuegos_categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Videojuegos_categorias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Videojuegos_categorias? Guardar(Videojuegos_categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Videojuegos_categorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Videojuegos_categorias> Listar()
        {
            return this.IConexion!.Videojuegos_categorias!.Take(20).ToList();
        }

        public Videojuegos_categorias? Modificar(Videojuegos_categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Videojuegos_categorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Videojuegos_categorias> ListarPorVideojuego(Videojuegos_categorias? entidad)
        {
            return this.IConexion!.Videojuegos_categorias!
                        .Where(x => x.Videojuego == entidad!.Videojuego).ToList();
        }

        public List<Videojuegos_categorias> ListarPorCategoria(Videojuegos_categorias? entidad)
        {
            return this.IConexion!.Videojuegos_categorias!
                        .Where(x => x.Categoria == entidad!.Categoria).ToList();
        }
    }
}
