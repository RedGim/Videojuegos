using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class Usuarios_rolesAplicacion : IUsuarios_rolesAplicacion
    {
        private IConexion? IConexion = null;
        
        public Usuarios_rolesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Usuarios_roles? Borrar(Usuarios_roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Usuarios_roles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios_roles? Guardar(Usuarios_roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            this.IConexion!.Usuarios_roles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios_roles> Listar()
        {
            return this.IConexion!.Usuarios_roles!.Take(20).ToList();
        }

        public Usuarios_roles? Modificar(Usuarios_roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Usuarios_roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Usuarios_roles> ListarPorRol(Usuarios_roles? entidad)
        {
            return this.IConexion!.Usuarios_roles!
                        .Where(x => x.Rol == entidad!.Rol).ToList();
        }

        public List<Usuarios_roles> ListarPorUsuario(Usuarios_roles? entidad)
        {
            return this.IConexion!.Usuarios_roles!
                        .Where(x => x.Usuario == entidad!.Usuario).ToList();
        }
    }
}