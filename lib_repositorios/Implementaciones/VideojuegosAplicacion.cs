using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class VideojuegosAplicacion : IVideojuegosAplicacion
    {
        private IConexion? IConexion = null;
        
        public VideojuegosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Videojuegos? Borrar(Videojuegos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Videojuegos!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Videojuegos? Guardar(Videojuegos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad.clasificacion == null)
                throw new Exception("lbNoexisteClasificacion");
            if (entidad.Desarrollador == null)
                throw new Exception("lbNoexisteDesarrollador");
            // Operaciones
            this.IConexion!.Videojuegos!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Videojuegos> Listar()
        {
            return this.IConexion!.Videojuegos!.Take(20).ToList();
        }

        public Videojuegos? Modificar(Videojuegos? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            if (entidad.clasificacion == null)
                throw new Exception("lbNoexisteClasificacion");
            if (entidad.Desarrollador == null)
                throw new Exception("lbNoexisteDesarrollador");
            // Operaciones
            var entry = this.IConexion!.Entry<Videojuegos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Videojuegos> ListarPorClasificacion(Videojuegos? entidad)
        {
            return this.IConexion!.Videojuegos!
                        .Where(x => x.clasificacion == entidad!.clasificacion).ToList();
        }

        public List<Videojuegos> ListarPorDesarrollador(Videojuegos? entidad)
        {
            return this.IConexion!.Videojuegos!
                        .Where(x => x.Desarrollador == entidad!.Desarrollador).ToList();
        }
    }
}