using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IUsuarios_roles_rolesAplicacion
    {
        void Configurar(string StringConexion);
        List<Usuarios_roles> Listar();
        Usuarios_roles? Guardar(Usuarios_roles? entidad);
        Usuarios_roles? Modificar(Usuarios_roles? entidad);
        Usuarios_roles? Borrar(Usuarios_roles? entidad);
    }
}