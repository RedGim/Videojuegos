using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class VideojuegosPrueba
    {
        private readonly IConexion iConexion;
        private readonly IVideojuegosAplicacion VideojuegosAplicacion;
        private Videojuegos? Videojuegoss;

        public VideojuegosPrueba()
        {
            iConexion = new Conexion();
            VideojuegosAplicacion = new VideojuegosAplicacion(iConexion);
            VideojuegosAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ListarRolPrueba());
            Assert.AreEqual(true, ListarUsuarioPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
            Assert.ThrowsException<Exception>(() => BorrarNuloPrueba());
        }

        public bool ListarRolPrueba()
        {
            var lista = VideojuegosAplicacion.ListarPorClasificacion(this.Videojuegoss);
            return lista.Count > 0;
        }

        public bool ListarUsuarioPrueba()
        {
            var lista = VideojuegosAplicacion.ListarPorDesarrollador(this.Videojuegoss);
            return lista.Count > 0;
        }

        public bool ListarPrueba()
        {
            var lista = VideojuegosAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Videojuegoss = EntidadesNucleo.Videojuegos();
            this.VideojuegosAplicacion.Guardar(this.Videojuegoss);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Videojuegoss!.Desarrollador = 3;
            this.Videojuegoss!.clasificacion = 2;
            this.VideojuegosAplicacion.Modificar(Videojuegoss);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.VideojuegosAplicacion.Borrar(this.Videojuegoss);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            VideojuegosAplicacion!.Borrar(null);
        }
    }
}
