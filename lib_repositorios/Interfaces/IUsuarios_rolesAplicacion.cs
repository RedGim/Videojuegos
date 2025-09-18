using lib_dominio.Entidades;
namespace lib_repositorios.Interfaces
{
    public interface IUsuarios_rolesAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios_roles> Listar();
        List<Usuarios_roles> ListarPorRol(Usuarios_roles? entidad);
        List<Usuarios_roles> ListarPorUsuario(Usuarios_roles? entidad);
        Usuarios_roles? Guardar(Usuarios_roles? entidad);
        Usuarios_roles? Modificar(Usuarios_roles? entidad);
        Usuarios_roles? Borrar(Usuarios_roles? entidad);
    }
}