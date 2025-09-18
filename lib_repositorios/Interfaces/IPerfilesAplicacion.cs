using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IPerfilesAplicacion
    {
        void Configurar(string StringConexion);
        List<Perfiles> Listar();
        List<Perfiles> ListarPorUsuarios(Perfiles? entidad);
        Perfiles? Guardar(Perfiles? entidad);
        Perfiles? Modificar(Perfiles? entidad);
        Perfiles? Borrar(Perfiles? entidad);
    }
}