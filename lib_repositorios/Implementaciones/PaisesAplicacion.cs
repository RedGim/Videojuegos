using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PaisesAplicacion : IPaisesAplicacion
    {
        private IConexion? IConexion = null;
        
        public PaisesAplicacion(IConexion iConexion)
        {
            this.IConexion = iConexion;
        }

        private bool ValidarNombrePaisUnico(string nombrePais)
        {

            var rolExistente = this.IConexion!.Roles!
                .FirstOrDefault(x => x.Nombre == nombrePais);

            return rolExistente == null;
        }

        public void Configurar(string StringConexion)
        {
            this.IConexion!.StringConexion = StringConexion;
        }

        public Paises? Borrar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            // Operaciones
            this.IConexion!.Paises!.Remove(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public Paises? Guardar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad.Id != 0)
                throw new Exception("lbYaSeGuardo");
            if (entidad!.Nombre == null || !ValidarNombrePaisUnico(entidad.Nombre))
                throw new Exception("El rol no es valido");
            // Operaciones
            this.IConexion!.Paises!.Add(entidad);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Paises> Listar()
        {
            return this.IConexion!.Paises!.Take(20).ToList();
        }

        public Paises? Modificar(Paises? entidad)
        {
            if (entidad == null)
                throw new Exception("lbFaltaInformacion");
            if (entidad!.Id == 0)
                throw new Exception("lbNoSeGuardo");
            if (entidad!.Nombre == null || !ValidarNombrePaisUnico(entidad.Nombre))
                throw new Exception("El rol no es valido");
            // Operaciones
            var entry = this.IConexion!.Entry<Paises>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion.SaveChanges();
            return entidad;
        }
    }
}