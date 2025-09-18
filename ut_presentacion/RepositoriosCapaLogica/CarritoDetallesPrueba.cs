using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class CarritoDetallesPrueba
    {
        private readonly IConexion iConexion;
        private readonly ICarritosDetalleAplicacion carritoDetalleAplicacion;
        private CarritoDetalles? carritosDetalle;

        public CarritoDetallesPrueba()
        {
            iConexion = new Conexion();
            carritoDetalleAplicacion = new CarritosDetalleAplicacion(iConexion);
            carritoDetalleAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
        }

        public bool ListarPrueba()
        {
            var lista = carritoDetalleAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.carritosDetalle = EntidadesNucleo.CarritoDetalles();
            this.carritoDetalleAplicacion.Guardar(this.carritosDetalle);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.carritosDetalle!.Cantidad = 5;
            this.carritosDetalle.Precio = 20.60m;
            this.carritoDetalleAplicacion.Modificar(carritosDetalle);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.carritoDetalleAplicacion.Borrar(this.carritosDetalle);
            return true;
        }
    }
}
