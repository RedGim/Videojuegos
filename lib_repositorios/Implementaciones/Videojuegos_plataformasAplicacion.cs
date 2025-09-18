using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Videojuegos_plataformasAplicacion: IVideojuegos_plataformasAplicacion
    {
        private IConexion? IConexion = null;

        public Videojuegos_plataformasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Videojuegos_plataformas? Borrar(Videojuegos_plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Videojuegos_plataformas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Videojuegos_plataformas? Guardar(Videojuegos_plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Videojuegos_plataformas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Videojuegos_plataformas> Listar()
        {
            return this.IConexion!.Videojuegos_plataformas!.Take(20).ToList();
        }

        public Videojuegos_plataformas? Modificar(Videojuegos_plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Videojuegos_plataformas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Videojuegos_plataformas> ListarPorVideojuego(Videojuegos_plataformas? entidad)
        {
            return this.IConexion!.Videojuegos_plataformas!
                        .Where(x => x.Videojuego == entidad!.Videojuego).ToList();
        }

        public List<Videojuegos_plataformas> ListarPorPlataforma(Videojuegos_plataformas? entidad)
        {
            return this.IConexion!.Videojuegos_plataformas!
                        .Where(x => x.Plataforma == entidad!.Plataforma).ToList();
        }
    }
}
