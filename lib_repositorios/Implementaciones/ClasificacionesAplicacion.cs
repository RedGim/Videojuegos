using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ClasificacionesAplicacion: IClasificacionesAplicacion
    {
            private IConexion? IConexion = null;

            public ClasificacionesAplicacion(IConexion iConexion)
            {
                this.IConexion = iConexion;
            }

            public static bool Validar(Clasificaciones clasificacion)
            {
                if (string.IsNullOrWhiteSpace(clasificacion.Nombre))
                {
                    throw new Exception("El nombre de la clasificación es obligatorio.");
                }

                if (clasificacion.Nombre.Length > 30)
                {
                    throw new Exception("El nombre de la clasificación no puede superar los 30 caracteres.");
                }

                if (clasificacion.Edad < 0)
                {
                    throw new Exception("La edad mínima no puede ser negativa.");
                }

                return true;
            }
            public void Configurar(string StringConexion)
            {
                this.IConexion!.StringConexion = StringConexion;
            }

            public Clasificaciones? Borrar(Clasificaciones? entidad)
            {
                if (entidad == null)
                    throw new Exception("lbFaltaInformacion");
                if (entidad!.Id == 0)
                    throw new Exception("lbNoSeGuardo");

            this.IConexion!.Clasificaciones!.Remove(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }

            public Clasificaciones? Guardar(Clasificaciones? entidad)
            {
                if (entidad == null)
                    throw new Exception("lbFaltaInformacion");
                if (entidad.Id != 0)
                    throw new Exception("lbYaSeGuardo");
                // Operaciones
                if (!Validar(entidad))
                    throw new Exception("lbNoEsValido");
                this.IConexion!.Clasificaciones!.Add(entidad);
                this.IConexion.SaveChanges();
                return entidad;
            }

            public List<Clasificaciones> Listar()
            {
                return this.IConexion!.Clasificaciones!.Take(20).ToList();
            }

            public Clasificaciones? Modificar(Clasificaciones? entidad)
            {
                if (entidad == null)
                    throw new Exception("lbFaltaInformacion");
                if (entidad!.Id == 0)
                    throw new Exception("lbNoSeGuardo");
            // Operaciones
                if (!Validar(entidad))
                    throw new Exception("lbNoEsValido");
                var entry = this.IConexion!.Entry<Clasificaciones>(entidad);
                entry.State = EntityState.Modified;
                this.IConexion.SaveChanges();
                return entidad;
            }
        
    }
}
