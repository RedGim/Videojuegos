using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class PlataformasPruebas
    {
        private readonly IConexion iConexion;
        private readonly IPlataformasAplicacion PlataformasAplicacion;
        private Plataformas? Plataformas;

        public PlataformasPruebas()
        {
            iConexion = new Conexion();
            PlataformasAplicacion = new PlataformasAplicacion(iConexion);
            PlataformasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = PlataformasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Plataformas = EntidadesNucleo.Plataformas();
            this.PlataformasAplicacion.Guardar(this.Plataformas);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Plataformas!.Nombre = "Test";
            this.PlataformasAplicacion.Modificar(Plataformas);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.PlataformasAplicacion.Borrar(this.Plataformas);
            return true;
        }
    }
}
