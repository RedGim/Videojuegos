using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace lib_repositorios.Implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion? IConexion = null;

        public RolesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        private bool ValidarNombreRolUnico(string nombreRol)
        {
           
            var rolExistente = this.IConexion!.Roles!
                .FirstOrDefault(x => x.Nombre == nombreRol);

            return rolExistente == null; 
        }


        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Roles? Borrar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Roles!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Roles? Guardar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad!.Nombre == null || !ValidarNombreRolUnico(entidad.Nombre))
                throw new Exception("El rol no es valido");
            // Operaciones
            this.IConexion!.Roles!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Listar()
        {
            return this.IConexion!.Roles!.Take(20).ToList();
        }

        public Roles? Modificar(Roles? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            if (entidad!.Nombre == null || !ValidarNombreRolUnico(entidad.Nombre))
                throw new Exception("El rol no es valido");
            // Operaciones
            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
