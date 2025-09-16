using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class BibliotecaPrueba
    {
        private readonly IConexion? iConexion;
        private List<Bibliotecas>? lista;
        private Bibliotecas? entidad;

        public BibliotecaPrueba()
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
            this.lista = this.iConexion!.Bibliotecas!.Include(x => x._Videojuego).Include(x => x._Usuario).ToList();
            return lista.Count > 0;
        }


        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Bibliotecas()!;
            this.iConexion!.Bibliotecas!.Add(this.entidad);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.VideoJuego = 3;
            var entry = this.iConexion!.Entry<Bibliotecas>(this.entidad!);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Bibliotecas!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

    }
}
