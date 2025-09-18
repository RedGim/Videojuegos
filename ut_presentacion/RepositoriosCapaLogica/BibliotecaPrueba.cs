using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class BibliotecaPrueba
    {
        private readonly IConexion iConexion;
        private readonly IBibliotecasAplicacion bibliotecasAplicacion;
        private Bibliotecas? bibliotecas;

        public BibliotecaPrueba()
        {
            iConexion = new Conexion();
            bibliotecasAplicacion = new BibliotecasAplicacion(iConexion);
            bibliotecasAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
        }


        [TestMethod]
        public void Ejecutar()
        {  
            Assert.AreEqual(true, GuardarPrueba());
            Assert.AreEqual(null, GuardarDuplicado());
            Assert.AreEqual(true, ListarVideojuegoPrueba());
            Assert.AreEqual(true, ListarUsuarioPrueba());
            Assert.AreEqual(true, ModificarPrueba());
            Assert.AreEqual(true, ListarPrueba());
            Assert.ThrowsException<Exception>(() => BorrarNuloPrueba());
            Assert.AreEqual(true, BorrarPrueba());

        }

        public bool ListarVideojuegoPrueba()
        {
            var lista = bibliotecasAplicacion.ListarPorVideojuegos(this.bibliotecas);
            return lista.Count > 0;
        }


        public bool ListarUsuarioPrueba()
        {
            var lista = bibliotecasAplicacion.ListarPorUsuario(this.bibliotecas);
            return lista.Count > 0;
        }

        public bool ListarPrueba()
        {
            var lista = bibliotecasAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.bibliotecas = EntidadesNucleo.Bibliotecas();
            this.bibliotecasAplicacion.Guardar(this.bibliotecas);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.bibliotecas!.VideoJuego = 3;
            this.bibliotecas!.Usuario = 2;
            this.bibliotecasAplicacion.Modificar(bibliotecas);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.bibliotecasAplicacion.Borrar(this.bibliotecas);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            bibliotecasAplicacion!.Borrar(null);
        }

        public Bibliotecas GuardarDuplicado()
        {
            var entidad = this.bibliotecasAplicacion.Guardar(this.bibliotecas);
            return entidad!;
        }
    }
}
