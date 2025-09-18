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
            Assert.ThrowsException<Exception>(() => GuardarCantidadNoValida());
            Assert.ThrowsException<Exception>(() => GuardarPrecioNoValido());
            Assert.ThrowsException<Exception>(() => GuardarVideojuegoInexistente());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.ThrowsException<Exception>(() => ModificarCantidadNoValida());
            Assert.ThrowsException<Exception>(() => ModificarPrecioNoValido());
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

        public void GuardarCantidadNoValida()
        {
            var entidad = new CarritoDetalles();
            entidad!.Carrito = 2;
            entidad!.VideoJuego = 3;
            entidad!.Cantidad = -1;
            entidad!.Precio = 4;
            this.carritoDetalleAplicacion.Guardar(entidad);
        }

        public void GuardarPrecioNoValido()
        {
            var entidad = new CarritoDetalles();
            entidad!.Carrito = 2;
            entidad!.VideoJuego = 3;
            entidad!.Cantidad = 4;
            entidad!.Precio = -1;
            this.carritoDetalleAplicacion.Guardar(entidad);
        }

        public bool ModificarPrueba()
        {
            this.carritosDetalle!.Cantidad = 5;
            this.carritosDetalle.Precio = 20.60m;
            this.carritoDetalleAplicacion.Modificar(carritosDetalle);
            return true;
        }

        public void ModificarCantidadNoValida()
        {
            this.carritosDetalle!.Cantidad = 0;
            this.carritoDetalleAplicacion.Modificar(carritosDetalle);
        }

        public void ModificarPrecioNoValido()
        {
            this.carritosDetalle!.Precio = -1;
            this.carritoDetalleAplicacion.Modificar(carritosDetalle);
        }

        public bool BorrarPrueba()
        {
            this.carritoDetalleAplicacion.Borrar(this.carritosDetalle);
            return true;
        }

        public void GuardarVideojuegoInexistente()
        {
            var entidad = new CarritoDetalles();
            entidad.Carrito = 1;
            entidad.Carrito = 1000;
            entidad.Cantidad = 2;
            entidad.Precio = 50;
            this.carritoDetalleAplicacion.Guardar(entidad);
        }
    }
}
