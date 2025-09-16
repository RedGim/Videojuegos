using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IResenasAplicacion
    {
        void Configurar(string StringConexion);

        List<Resenas> Listar();
        Resenas? Guardar(Resenas? entidad);
        Resenas? Modificar(Resenas? entidad);
        Resenas? Borrar(Resenas? entidad);
        List<Resenas> ListarPorVideojuegos(Resenas? entidad);
        List<Resenas> ListarPorUsuario(Resenas? entidad);
    }
}
