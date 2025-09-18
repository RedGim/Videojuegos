using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Usuarios_rolesPruebas
    {
        private readonly IConexion? iConexion;
        private List<Usuarios_roles>? lista;
        private Usuarios_roles? entidad;

        public Usuarios_rolesPruebas()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Listar()
        {
            this.lista = this.iConexion!.Usuarios_roles!.Include(x => x._Roles).Include(x => x._Usuarios).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Usuarios_roles()!;
            this.iConexion!.Usuarios_roles!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Rol = 1;
            var entry = this.iConexion!.Entry<Usuarios_roles>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Usuarios_roles!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
