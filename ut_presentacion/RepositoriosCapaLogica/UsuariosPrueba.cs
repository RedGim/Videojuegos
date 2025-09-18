using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class UsuariosPrueba
    {
        private readonly IConexion iConexion;
        private readonly IUsuariosAplicacion UsuariossAplicacion;
        private Usuarios? Usuarioss;

        public UsuariosPrueba()
        {
            iConexion = new Conexion();
            UsuariossAplicacion = new UsuariosAplicacion(iConexion);
            UsuariossAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(true, ListarPaisPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
            Assert.ThrowsException<Exception>(() => BorrarNuloPrueba());
        }

        public bool ListarPaisPrueba()
        {
            var lista = UsuariossAplicacion.ListarPorPaises(this.Usuarioss);
            return lista.Count > 0;
        }


        public bool ListarPrueba()
        {
            var lista = UsuariossAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Usuarioss = EntidadesNucleo.Usuarios();
            this.UsuariossAplicacion.Guardar(this.Usuarioss);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Usuarioss!.Pais = 3;
            this.Usuarioss!.Correo = "CambioCorreoPrueba@pruebapruebita.com";
            this.UsuariossAplicacion.Modificar(Usuarioss);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.UsuariossAplicacion.Borrar(this.Usuarioss);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            UsuariossAplicacion!.Borrar(null);
        }
    }
}
