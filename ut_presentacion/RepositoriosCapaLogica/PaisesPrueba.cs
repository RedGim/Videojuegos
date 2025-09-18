using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class PaisesPrueba
    {
        private readonly IConexion iConexion;
        private readonly IPaisesAplicacion PaisesAplicacion;
        private Paises? Paises;

        public PaisesPrueba()
        {
            iConexion = new Conexion();
            PaisesAplicacion = new PaisesAplicacion(iConexion);
            PaisesAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = PaisesAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Paises = EntidadesNucleo.Paises();
            this.PaisesAplicacion.Guardar(this.Paises);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Paises!.Nombre = "Test";
            this.PaisesAplicacion.Modificar(Paises);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.PaisesAplicacion.Borrar(this.Paises);
            return true;
        }
    }
}
