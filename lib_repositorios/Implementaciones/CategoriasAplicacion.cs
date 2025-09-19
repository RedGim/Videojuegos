using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CategoriasAplicacion: ICategoriasAplicacion
    {
        private IConexion? IConexion = null;

        public CategoriasAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }
        public static bool Validar(Categorias Categorias)
        {
            if (string.IsNullOrWhiteSpace(Categorias.Nombre))
            {
                throw new Exception("El nombre de la categoria es obligatorio.");
            }

            if (Categorias.Nombre.Length > 50)
            {
                throw new Exception("El nombre de la categoria no puede superar los 50 caracteres.");
            }

            if (Categorias.Nombre.Length > 300)
            {
                throw new Exception("El nombre de la descripcion no puede superar los 300 caracteres.");
            }

            return true;
        }
        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Categorias? Borrar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            this.IConexion!.Categorias!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Categorias? Guardar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            // Operaciones
            if (!Validar(entidad))
                throw new Exception("lbNoEsValido");
            this.IConexion!.Categorias!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Categorias> Listar()
        {
            return this.IConexion!.Categorias!.Take(20).ToList();
        }

        public Categorias? Modificar(Categorias? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            if (!Validar(entidad))
                throw new Exception("lbNoEsValido");
            var entry = this.IConexion!.Entry<Categorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}
