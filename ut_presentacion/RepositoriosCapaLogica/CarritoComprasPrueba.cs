using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class CarritoComprasPrueba
    {
        private readonly IConexion iConexion;
        private readonly ICarritosCompraAplicacion carritoAplicacion;
        private CarritoCompras? carritos;

        public CarritoComprasPrueba()
        {
            iConexion = new Conexion();
            carritoAplicacion = new CarritosCompraAplicacion(iConexion);
            carritoAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, ListarPorUsuarioPrueba());
            Assert.AreEqual(true, BorrarPrueba());
        }

        public bool ListarPrueba()
        {
            var lista = carritoAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool ListarPorUsuarioPrueba()
        {
            var lista = carritoAplicacion.ListarPorUsuario(this.carritos!);
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.carritos = EntidadesNucleo.CarritoCompras();
            this.carritoAplicacion.Guardar(this.carritos);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.carritos!.Usuario = 2;
            this.carritos!.Estado = false;
            this.carritoAplicacion.Modificar(carritos);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.carritoAplicacion.Borrar(this.carritos);
            return true;
        }
    }
}
