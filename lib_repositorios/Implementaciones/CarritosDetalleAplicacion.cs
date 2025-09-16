using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CarritosDetalleAplicacion : ICarritosDetalleAplicacion
    {
        private readonly IConexion iConexion;

        public CarritosDetalleAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }


        public void Configurar(string StringConexion)
        {
            this.iConexion.StringConexion = StringConexion;
        }


        public CarritoDetalles? Borrar(CarritoDetalles? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }

            this.iConexion!.CarritoDetalles!.Remove(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public CarritoDetalles? Guardar(CarritoDetalles? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id != 0)
            {
                throw new Exception("Ya se guardó");
            }

            this.iConexion!.CarritoDetalles!.Add(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<CarritoDetalles> Listar()
        {
            return this.iConexion!.CarritoDetalles!.ToList();
        }

        public CarritoDetalles? Modificar(CarritoDetalles? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }

            var entry = this.iConexion!.Entry<CarritoDetalles>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }
    }
}
