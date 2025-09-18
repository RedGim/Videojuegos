using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IDesarrolladoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Desarrolladores> Listar();
        List<Desarrolladores> ListarPorPais(Desarrolladores? entidad);
        Desarrolladores? Guardar(Desarrolladores? entidad);
        Desarrolladores? Modificar(Desarrolladores? entidad);
        Desarrolladores? Borrar(Desarrolladores? entidad);
    }
}
