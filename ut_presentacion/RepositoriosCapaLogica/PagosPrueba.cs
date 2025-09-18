using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class PagosPrueba
    {
        private readonly IConexion iConexion;
        private readonly IPagosAplicacion pagosAplicacion;
        private Pagos? pagos;

        public PagosPrueba()
        {
            iConexion = new Conexion();
            pagosAplicacion = new PagosAplicacion(iConexion);
            pagosAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.ThrowsException<Exception>(() => GuardarMontoNoValido());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, ListarPorUsuarioPrueba());
            Assert.AreEqual(true, BorrarPrueba());
        }

        public bool ListarPrueba()
        {
            var lista = pagosAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool ListarPorUsuarioPrueba()
        {
            var lista = pagosAplicacion.ListarPorUsuario(this.pagos);
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.pagos = EntidadesNucleo.Pagos();
            this.pagosAplicacion.Guardar(this.pagos);
            return true;
        }

        public void GuardarMontoNoValido()
        {
            var entidad = new Pagos();
            entidad!.Usuario = 2;
            entidad!.Monto = -1;
            entidad!.MetodoPago = "Tarjeta de Crédito";
            entidad!.Fecha = DateTime.Now;
            this.pagosAplicacion.Guardar(entidad);
        }

        public bool BorrarPrueba()
        {
            this.pagosAplicacion.Borrar(this.pagos);
            return true;
        }
    }
}
