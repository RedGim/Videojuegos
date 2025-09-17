using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class Usuarios_rolesPrueba
    {
        private readonly IConexion iConexion;
        private readonly IUsuarios_rolesAplicacion Usuarios_rolesAplicacion;
        private Usuarios_roles? Usuarios_roless;

        public Usuarios_rolesPrueba()
        {
            iConexion = new Conexion();
            Usuarios_rolesAplicacion = new Usuarios_rolesAplicacion(iConexion);
            Usuarios_rolesAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = Usuarios_rolesAplicacion.ListarPorVideojuegos(this.Usuarios_roless);
            return lista.Count > 0;
        }

        public bool ListarUsuarioPrueba()
        {
            var lista = Usuarios_rolesAplicacion.ListarPorUsuario(this.Usuarios_roless);
            return lista.Count > 0;
        }

        public bool ListarPrueba()
        {
            var lista = Usuarios_rolesAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Usuarios_roless = EntidadesNucleo.Usuarios_roles();
            this.Usuarios_rolesAplicacion.Guardar(this.Usuarios_roless);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Usuarios_roless!.Rol = 3;
            this.Usuarios_roless!.Usuario = 2;
            this.Usuarios_rolesAplicacion.Modificar(Usuarios_roless);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.Usuarios_rolesAplicacion.Borrar(this.Usuarios_roless);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            Usuarios_rolesAplicacion!.Borrar(null);
        }
    }
}
