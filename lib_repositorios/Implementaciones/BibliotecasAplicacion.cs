using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class BibliotecasAplicacion : IBibliotecasAplicacion
    {
        private readonly IConexion? iConexion;


        public BibliotecasAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }

        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }

        public Bibliotecas? Borrar(Bibliotecas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }   

            this.iConexion!.Bibliotecas!.Remove(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public Bibliotecas? Guardar(Bibliotecas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id != 0)
            {
                throw new Exception("Ya se guardó");
            }

            this.iConexion!.Bibliotecas!.Add(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<Bibliotecas> Listar()
        {
            return this.iConexion!.Bibliotecas!.ToList();
        }

        public Bibliotecas? Modificar(Bibliotecas? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }

            var entry = this.iConexion!.Entry<Bibliotecas>(entidad);
            entry.State = EntityState.Modified;
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<Bibliotecas> ListarPorVideojuegos(Bibliotecas? entidad)
        {
            return this.iConexion!.Bibliotecas!
                        .Where(x => x.VideoJuego == entidad!.VideoJuego).ToList();
        }

        public List<Bibliotecas> ListarPorUsuario(Bibliotecas? entidad)
        {
            return this.iConexion!.Bibliotecas!
                        .Where(x => x.Usuario == entidad!.Usuario).ToList();
        }
    }
}
