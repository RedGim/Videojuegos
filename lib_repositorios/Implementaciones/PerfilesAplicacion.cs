using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PerfilesAplicacion : IPerfilesAplicacion
    {
        private IConexion? IConexion = null;
        
        public PerfilesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Perfiles? Borrar(Perfiles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Perfiles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Perfiles? Guardar(Perfiles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad!.Usuario == null)
                throw new Exception("lbNecesitaunusuario");
            // Operaciones
            this.IConexion!.Perfiles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Perfiles> Listar()
        {
            return this.IConexion!.Perfiles!.Take(20).ToList();
        }

        public Perfiles? Modificar(Perfiles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
             if (entidad!.Usuario == null)
                throw new Exception("lbNecesitaunusuario");
            // Operaciones
            var entry = this.IConexion!.Entry<Perfiles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Perfiles> ListarPorUsuarios(Perfiles? entidad)
        {
            return this.IConexion!.Perfiles!
                        .Where(x => x.Usuario == entidad!.Usuario).ToList();
        }

    }
}
