using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class CarritosCompraAplicacion : ICarritosCompraAplicacion
    {
        private readonly IConexion iConexion;

        public CarritosCompraAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion.StringConexion = StringConexion;
        }


        public CarritoCompras? Borrar(CarritoCompras? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }

            this.iConexion!.CarritoCompras!.Remove(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public CarritoCompras? Guardar(CarritoCompras? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id != 0)
            {
                throw new Exception("Ya se guardó");
            }
            this.iConexion!.CarritoCompras!.Add(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<CarritoCompras> Listar()
        {
            return this.iConexion!.CarritoCompras!.ToList();
        }

        public CarritoCompras? Modificar(CarritoCompras? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }
            var entry = this.iConexion!.Entry<CarritoCompras>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion.SaveChanges();
            return entidad;
        }

        public List<CarritoCompras> ListarPorUsuario(CarritoCompras? entidad)
        {
            return this.iConexion!.CarritoCompras!.Where(x => x.Usuario == entidad!.Usuario).ToList();
        }
    }
}
