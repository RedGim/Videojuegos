using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    internal interface IDesarrolladoresAplicacion
    {
        void Configurar(string StringConexion);
        List<Desarrolladores> Listar();
        Desarrolladores? Guardar(Desarrolladores? entidad);
        Desarrolladores? Modificar(Desarrolladores? entidad);
        Desarrolladores? Borrar(Desarrolladores? entidad);
    }
}
