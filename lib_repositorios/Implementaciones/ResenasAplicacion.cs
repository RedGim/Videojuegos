using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class ResenasAplicacion : IResenasAplicacion
    {
        private readonly IConexion iConexion;


        public ResenasAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }


        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }


        public Resenas? Borrar(Resenas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Reseña no enviada");
            }
            if (entidad!.Id == 0)
            {
                throw new Exception("El registro ya se guardó");
            }

            this.iConexion!.Resenas!.Remove(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public Resenas? Guardar(Resenas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Reseña no enviada");
            }
            if (entidad!.Id != 0)
            {
                throw new Exception("El registro ya se guardó");
            }

            this.iConexion!.Resenas!.Add(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<Resenas> Listar()
        {
            return this.iConexion!.Resenas!.ToList();
        }

        public Resenas? Modificar(Resenas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Reseña no enviada");
            }
            if (entidad!.Id == 0)
            {
                throw new Exception("El registro ya se guardó");
            }

            var entry = this.iConexion!.Entry<Resenas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<Resenas> ListarPorVideojuegos(Resenas? entidad)
        {
            return this.iConexion!.Resenas!
                    .Where(x => x.VideoJuego == entidad!.VideoJuego).ToList();
        }

        public List<Resenas> ListarPorUsuario(Resenas? entidad)
        {
            return this.iConexion!.Resenas!
                    .Where(x => x.Usuario == entidad!.Usuario).ToList();
        }
    }
}
