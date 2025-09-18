using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class Videojuegos_plataformasPrueba
    {
        private readonly IConexion iConexion;
        private readonly IVideojuegos_plataformasAplicacion Videojuegos_plataformasAplicacion;
        private Videojuegos_plataformas? Videojuegos_plataformas;

        public Videojuegos_plataformasPrueba()
        {
            iConexion = new Conexion();
            Videojuegos_plataformasAplicacion = new Videojuegos_plataformasAplicacion(iConexion);
            Videojuegos_plataformasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = Videojuegos_plataformasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Videojuegos_plataformas = EntidadesNucleo.Videojuegos_plataformas();
            this.Videojuegos_plataformasAplicacion.Guardar(this.Videojuegos_plataformas);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Videojuegos_plataformas!.Videojuego = 3;
            this.Videojuegos_plataformas!.Plataforma = 5;
            this.Videojuegos_plataformasAplicacion.Modificar(Videojuegos_plataformas);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.Videojuegos_plataformasAplicacion.Borrar(this.Videojuegos_plataformas);
            return true;
        }
    }
}
