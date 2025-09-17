using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using ut_presentacion.Nucleo;

namespace ut_presentacion.PruebaCapaLogica
{
    [TestClass]
    public class PerfilesPrueba
    {
        private readonly IConexion iConexion;
        private readonly IPerfilesAplicacion PerfilessAplicacion;
        private Perfiles? Perfiless;

        public PerfilesPrueba()
        {
            iConexion = new Conexion();
            PerfilessAplicacion = new PerfilesAplicacion(iConexion);
            PerfilessAplicacion.Configurar(Configuracion.ObtenerValor("StringConexion"));
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
            var lista = PerfilessAplicacion.ListarPorUsuarios(this.Perfiless);
            return lista.Count > 0;
        }


        public bool ListarPrueba()
        {
            var lista = PerfilessAplicacion.Listar();
            return lista.Count > 0;
        }

        public bool GuardarPrueba()
        {
            this.Perfiless = EntidadesNucleo.Perfiles();
            this.PerfilessAplicacion.Guardar(this.Perfiless);
            return true;
        }

        public bool ModificarPrueba()
        {
            this.Perfiless!.Usuario = 3;
            this.PerfilessAplicacion.Modificar(Perfiless);
            return true;
        }

        public bool BorrarPrueba()
        {
            this.PerfilessAplicacion.Borrar(this.Perfiless);
            return true;
        }

        public void BorrarNuloPrueba()
        {
            PerfilessAplicacion!.Borrar(null);
        }
    }
}
