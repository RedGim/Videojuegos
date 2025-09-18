using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class RolesPrueba
    {
        private readonly IConexion iConexion;
        private readonly IRolesAplicacion RolesAplicacion;
        private Roles? Roles;

        public RolesPrueba()
        {
            iConexion = new Conexion();
            RolesAplicacion = new RolesAplicacion(iConexion);
            RolesAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = RolesAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Roles = EntidadesNucleo.Roles();
            this.RolesAplicacion.Guardar(this.Roles);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Roles!.Nombre = "Test";
            this.Roles!.Activo = false;
            this.Roles!.Fecha_creacion = DateTime.Now;
            this.RolesAplicacion.Modificar(Roles);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.RolesAplicacion.Borrar(this.Roles);
            return true;
        }
    }
}
