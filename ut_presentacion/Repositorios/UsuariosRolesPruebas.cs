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
        private List<Usuarios_roles>? Usuarios_roles;
        private Usuarios_roles? Resena;

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
            this.Usuarios_roles = this.iConexion!.Usuarios_roles!.Include(x => x._Usuario).Include(x => x._Videojuego).ToList();
            return true;
        }


        public bool Guardar()
        {
            this.Resena = EntidadesNucleo.Usuarios_roles();
            this.iConexion!.Usuarios_roles!.Add(this.Resena!);
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.Resena!.VideoJuego = 5;
            this.Resena!.Comentario = "Ya no me gusta este juego";
            var entidad = this.iConexion!.Entry<Usuarios_roles>(this.Resena!);
            entidad.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Usuarios_roles!.Remove(this.Resena!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
