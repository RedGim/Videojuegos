using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class Videojuegos_categoriasPrueba
    {
        private readonly IConexion iConexion;
        private readonly IVideojuegos_categoriasAplicacion Videojuegos_categoriasAplicacion;
        private Videojuegos_categorias? Videojuegos_categorias;

        public Videojuegos_categoriasPrueba()
        {
            iConexion = new Conexion();
            Videojuegos_categoriasAplicacion = new Videojuegos_categoriasAplicacion(iConexion);
            Videojuegos_categoriasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = Videojuegos_categoriasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Videojuegos_categorias = EntidadesNucleo.Videojuegos_categorias();
            this.Videojuegos_categoriasAplicacion.Guardar(this.Videojuegos_categorias);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Videojuegos_categorias!.Videojuego = 3;
            this.Videojuegos_categorias!.Categoria = 5;
            this.Videojuegos_categoriasAplicacion.Modificar(Videojuegos_categorias);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.Videojuegos_categoriasAplicacion.Borrar(this.Videojuegos_categorias);
            return true;
        }
    }
}
