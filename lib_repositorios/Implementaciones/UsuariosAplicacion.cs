using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace lib_repositorios.Implementaciones
{
    public class UsuariosAplicacion : IUsuariosAplicacion
    {
        private IConexion? IConexion = null;
        
        public UsuariosAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        private bool ValidarContraseña(string contraseña)
        {            
            if (contraseña.Length < 8)
                return false;
            if (!Regex.IsMatch(contraseña, @"[a-zA-Z]"))
                return false;
            if (!Regex.IsMatch(contraseña, @"\d"))
                return false;

            return true;
        }

        private bool ValidarCorreo(string correo)
        {
             var usuarioExistente = this.IConexion!.Usuarios!.FirstOrDefault(x => x.Correo == correo);

            return usuarioExistente == null; 
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Usuarios? Borrar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Usuarios!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Usuarios? Guardar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad!.Pais == null)
                throw new Exception("lbFaltapais");
            if (entidad!.Contrasena == null || !ValidarContraseña(entidad.Contrasena))
                throw new Exception("La contraseña debe tener al menos 8 caracteres, contener al menos una letra y un número.");
            if (entidad!.Correo == null || !ValidarCorreo(entidad.Correo))
                throw new Exception("El correo electrónico ya está registrado.");
            if (entidad!.Fecha_nacimiento > DateTime.Now)
                throw new Exception("La persona no ha nacdido");
            // Operaciones
            this.IConexion!.Usuarios!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Usuarios> Listar()
        {
            return this.IConexion!.Usuarios!.Take(20).ToList();
        }

        public Usuarios? Modificar(Usuarios? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            if (entidad!.Contrasena == null || !ValidarContraseña(entidad.Contrasena))
                throw new Exception("La contraseña debe tener al menos 8 caracteres, contener al menos una letra y un número.");
            if (entidad!.Correo == null || !ValidarCorreo(entidad.Correo))
                throw new Exception("El correo electrónico ya está registrado.");
            if (entidad!.Fecha_nacimiento > DateTime.Now)
                throw new Exception("La persona no ha nacdido");
            // Operaciones
            var entry = this.IConexion!.Entry<Usuarios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
        public List<Usuarios> ListarPorPaises(Usuarios? entidad)
        {
            return this.IConexion!.Usuarios!
                        .Where(x => x.Pais == entidad!.Pais).ToList();
        }

    }
}