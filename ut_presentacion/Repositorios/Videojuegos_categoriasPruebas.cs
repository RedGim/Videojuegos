using lib_dominio.Entidades;
using lib_repositorios.Implementaciones;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ut_presentacion.Nucleo;

namespace ut_presentacion.Repositorios
{
    [TestClass]
    public class Videojuegos_categoriasPruebas
    {
        private readonly IConexion? iConexion;
        private List<Videojuegos_categorias>? lista;
        private Videojuegos_categorias? entidad;

        public Videojuegos_categoriasPruebas()
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
            this.lista = this.iConexion!.Videojuegos_categorias!.Include(x => x._Videojuego).Include(x => x._Categoria).ToList();
            return lista.Count > 0;
        }

        public bool Guardar()
        {
            this.entidad = EntidadesNucleo.Videojuegos_categorias()!;
            this.iConexion!.Videojuegos_categorias!.Add(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Modificar()
        {
            this.entidad!.Categoria = 2;
            var entry = this.iConexion!.Entry<Videojuegos_categorias>(this.entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return true;
        }

        public bool Borrar()
        {
            this.iConexion!.Videojuegos_categorias!.Remove(this.entidad!);
            this.iConexion!.SaveChanges();
            return true;
        }
    }
}
