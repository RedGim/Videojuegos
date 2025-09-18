using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class DesarrolladoresAplicacion : IDesarrolladoresAplicacion
    {
        private IConexion? IConexion = null;

        public DesarrolladoresAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Desarrolladores? Borrar(Desarrolladores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Desarrolladores!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Desarrolladores? Guardar(Desarrolladores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Desarrolladores!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Desarrolladores> Listar()
        {
            return this.IConexion!.Desarrolladores!.Take(20).ToList();
        }

        public Desarrolladores? Modificar(Desarrolladores? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Desarrolladores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Desarrolladores> ListarPorPais(Desarrolladores? entidad)
        {
            return this.IConexion!.Desarrolladores!
                        .Where(x => x.Pais == entidad!.Pais).ToList();
        }
    }
}
