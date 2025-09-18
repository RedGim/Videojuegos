using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class CategoriasPruebas
    {
        private readonly IConexion iConexion;
        private readonly ICategoriasAplicacion CategoriasAplicacion;
        private Categorias? Categorias;

        public CategoriasPruebas()
        {
            iConexion = new Conexion();
            CategoriasAplicacion = new CategoriasAplicacion(iConexion);
            CategoriasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = CategoriasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Categorias = EntidadesNucleo.Categorias();
            this.CategoriasAplicacion.Guardar(this.Categorias);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Categorias!.Nombre = "Test";
            this.Categorias!.Descripcion = "Test";
            this.CategoriasAplicacion.Modificar(Categorias);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.CategoriasAplicacion.Borrar(this.Categorias);
            return true;
        }
    }
}
