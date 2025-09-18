using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CarritoDetallesPrueba
    {
        private readonly IConexion? iConexion;
        private List<CarritoDetalles>? lista;
        private CarritoDetalles? entidad;

        public CarritoDetallesPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Borrar()
        {
            this.iConexion!.CarritoDetalles!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Cantidad = 10;
            this.entidad!.Precio = this.entidad!.Precio * this.entidad!.Cantidad;
            var entry = this.iConexion!.Entry<CarritoDetalles>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.CarritoDetalles();
            this.iConexion!.CarritoDetalles!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.CarritoDetalles!.Include(x => x.CarritoCompras).Include(x => x.Videojuegos).ToList();
            return lista.Count > 0;
        }
    }
}
