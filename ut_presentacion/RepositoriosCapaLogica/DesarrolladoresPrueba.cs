using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;
namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class DesarrolladoresPrueba
    {
        private readonly IConexion iConexion;
        private readonly IDesarrolladoresAplicacion DesarrolladoresAplicacion;
        private Desarrolladores? Desarrolladores;

        public DesarrolladoresPrueba()
        {
            iConexion = new Conexion();
            DesarrolladoresAplicacion = new DesarrolladoresAplicacion(iConexion);
            DesarrolladoresAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = DesarrolladoresAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Desarrolladores = EntidadesNucleo.Desarrolladores();
            this.DesarrolladoresAplicacion.Guardar(this.Desarrolladores);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Desarrolladores!.NombreEstudio = "Test";
            this.Desarrolladores!.Pais = 5;
            this.Desarrolladores!.web = "test/test.com";
            this.DesarrolladoresAplicacion.Modificar(Desarrolladores);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.DesarrolladoresAplicacion.Borrar(this.Desarrolladores);
            return true;
        }
    }
}
