using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using System.Runtime.CompilerServices;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class ResenasPruebas
    {
        private readonly IConexion iConexion;
        private readonly IResenasAplicacion resenasAplicacion;
        private Resenas? resenas;

        public ResenasPruebas()
        {
            iConexion = new Conexion();
            resenasAplicacion = new ResenasAplicacion(iConexion);
            resenasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, GuardarPrueba());
            Assert.ThrowsException<Exception>(() => GuardarCalificacionNoValida());
            Assert.ThrowsException<Exception>(() => GuardarDuplicado());
            Assert.AreEqual(true, ListarVideojuegoPrueba());
            Assert.AreEqual(true, ListarUsuarioPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.ThrowsException<Exception>(() => ModificarCalificacionNoValida());
            Assert.AreEqual(true, ListarPrueba());
            Assert.AreEqual(true, BorrarPrueba());
        }

        public bool ListarPrueba()
        {
            var lista = resenasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.resenas = EntidadesNucleo.Resenas();
            this.resenasAplicacion.Guardar(this.resenas);
            return true;
        }

        public void GuardarCalificacionNoValida()
        {
            var entidad = new Resenas();
            entidad!.Usuario = 1;
            entidad!.VideoJuego = 2;
            entidad!.Calificacion = 0;
            entidad!.Comentario = "Hubiera hecho un curso de python con las 80 horas q desperdicie en este juego";
            entidad!.Fecha = DateTime.Now;
            this.resenasAplicacion.Guardar(entidad);
        }

        public Resenas GuardarDuplicado()
        {
            var entidad = this.resenasAplicacion.Guardar(this.resenas);
            return entidad!;
        }

        public bool ModificarPrueba()
        {
            this.resenas!.VideoJuego = 3;
            this.resenas!.Usuario = 2;
            this.resenas!.Comentario = "Me gustó más el juego después de las 100 horas";
            this.resenasAplicacion.Modificar(resenas);
            return true;
        }

        public void ModificarCalificacionNoValida() 
        {
            this.resenas!.Calificacion = 6;
            this.resenasAplicacion.Modificar(resenas);
        }

        public bool BorrarPrueba()
        {
            this.resenasAplicacion.Borrar(this.resenas);
            return true;
        }

        public bool ListarUsuarioPrueba()
        {
            var lista = resenasAplicacion.ListarPorUsuario(this.resenas);
            return lista.Count > 0;
        }

        public bool ListarVideojuegoPrueba()
        {
            var lista = resenasAplicacion.ListarPorVideojuegos(this.resenas);
            return lista.Count > 0;
        }
    }
}
