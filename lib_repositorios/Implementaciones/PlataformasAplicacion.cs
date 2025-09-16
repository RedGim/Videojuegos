using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    internal class PlataformasAplicacion : IPlataformasAplicacion
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
