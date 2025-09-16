using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class ResenasPruebas
    {
        private readonly IConexion? iConexion;
        private List<Resenas>? Resenas;
        private Resenas? Resena;

        public ResenasPruebas()
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
            this.Resenas = this.iConexion!.Resenas!.Include(x => x._Usuario).Include(x => x._Videojuego).ToList();
            return true;
        }


        public bool Guardar()
        {
            this.Resena = EntidadesNucleo.Resenas();
            this.iConexion!.Resenas!.Add(this.Resena!);
            this.iConexion.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.Resena!.VideoJuego = 5;
            this.Resena!.Comentario = "Ya no me gusta este juego";
            var entidad = this.iConexion!.Entry<Resenas>(this.Resena!);
            entidad.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Resenas!.Remove(this.Resena!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
