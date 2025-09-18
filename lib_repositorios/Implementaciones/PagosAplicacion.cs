using lib_dominio.Entidades;
using lib_repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_repositorios.Implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private readonly IConexion iConexion;

        public PagosAplicacion(IConexion iConexion)
        {
            this.iConexion = iConexion;
        }


        public void Configurar(string StringConexion)
        {
            this.iConexion!.StringConexion = StringConexion;
        }


        public Pagos? Borrar(Pagos? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id == 0)
            {
                throw new Exception("Id no valido");
            }

            this.iConexion!.Pagos!.Remove(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public Pagos? Guardar(Pagos? entidad)
        {
            if (entidad == null)
            {
                throw new Exception("Registro no enviado");
            }
            if (entidad.Id != 0)
            {
                throw new Exception("Pago ya se guardó");
            }
            if (entidad.Monto < 0)
            {
                throw new Exception("Monto inválido");
            }

            this.iConexion!.Pagos!.Add(entidad);
            this.iConexion!.SaveChanges();
            return entidad;
        }

        public List<Pagos> Listar()
        {
            return this.iConexion!.Pagos!.ToList();
        }

        public List<Pagos> ListarPorUsuario(Pagos? entidad)
        {
            return this.iConexion!.Pagos!.Where(x => x.Usuario==entidad!.Usuario).ToList();
        }
    }
}
