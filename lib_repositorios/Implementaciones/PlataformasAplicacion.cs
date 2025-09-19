using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PlataformasAplicacion : IPlataformasAplicacion
    {
        private IConexion? IConexion = null;

        public PlataformasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }
        public static bool Validar(Plataformas clasificacion)
        {
            if (string.IsNullOrWhiteSpace(clasificacion.Nombre))
            {
                throw new Exception("El nombre de la Plataforma es obligatorio.");
            }

            if (clasificacion.Nombre.Length > 30)
            {
                throw new Exception("El nombre de la Plataforma no puede superar los 30 caracteres.");
            }

            return true;
        }

        public Plataformas? Borrar(Plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Plataformas!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Plataformas? Guardar(Plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            if (!Validar(entidad))
                throw new Exception("lbNoEsValido");
            this.IConexion!.Plataformas!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Plataformas> Listar()
        {
            return this.IConexion!.Plataformas!.Take(20).ToList();
        }

        public Plataformas? Modificar(Plataformas? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            var entry = this.IConexion!.Entry<Plataformas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
