using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class PagosPrueba
    {
        private Pagos? entidad {  get; set; }
        private readonly IConexion? iConexion;
        private List<Pagos>? Lista { get; set; }


        public PagosPrueba()
        {
            iConexion = new Conexion();
            iConexion.StringConexion = Configuracion.ObtenerValor("StringConexion");
        }

        [TestMethod]
        public void Ejecutar()
        {
            Assert.AreEqual(true, Guardar());
            Assert.AreEqual(true, Listar());
            Assert.AreEqual(true, Modificar());
            Assert.AreEqual(true, Borrar());
        }

        public bool Borrar()
        {
            this.iConexion!.Pagos!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Monto = 100.23m;
            this.entidad!.Usuario = 1;
            var entry = this.iConexion!.Entry<Pagos>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Pagos();
            this.iConexion!.Pagos!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Listar()
        {
            this.Lista = this.iConexion!.Pagos!.Include(x => x._Usuario).ToList();
            return Lista.Count > 0;
        }
    }
}
