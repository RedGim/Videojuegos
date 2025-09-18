using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class CarritoComprasPrueba
    {
        private readonly IConexion? iConexion;
        private List<CarritoCompras>? lista;
        private CarritoCompras? entidad;


        public CarritoComprasPrueba()
        {
            this.iConexion = new Conexion();
            this.iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
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
            this.lista = this.iConexion!.CarritoCompras!.Include(x => x._Usuario).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.CarritoCompras();
            this.iConexion!.CarritoCompras!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.FechaModificacIon = DateTime.Parse("2025-09-13 14:30:00");
            this.entidad!.Usuario = 1;
            var entidad = this.iConexion!.Entry<CarritoCompras>(this.entidad!);
            entidad.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.CarritoCompras!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
