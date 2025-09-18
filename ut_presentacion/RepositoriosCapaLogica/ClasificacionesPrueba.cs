using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class ClasificacionesPrueba
    {
        private readonly IConexion iConexion;
        private readonly IClasificacionesAplicacion ClasificacionesAplicacion;
        private Clasificaciones? clasificaciones;

        public ClasificacionesPrueba()
        {
            iConexion = new Conexion();
            ClasificacionesAplicacion = new ClasificacionesAplicacion(iConexion);
            ClasificacionesAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = ClasificacionesAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.clasificaciones = EntidadesNucleo.Clasificaciones();
            this.ClasificacionesAplicacion.Guardar(this.clasificaciones);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.clasificaciones!.Nombre = "Test";
            this.clasificaciones!.Edad = 5;
            this.ClasificacionesAplicacion.Modificar(clasificaciones);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.ClasificacionesAplicacion.Borrar(this.clasificaciones);
            return true;
        }
    }
}
