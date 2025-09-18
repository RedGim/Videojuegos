using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVideojuegos_plataformasAplicacion
    {
        void Configurar(string StringConexion);
        List<Videojuegos_plataformas> Listar();
        List<Videojuegos_plataformas> ListarPorVideojuego(Videojuegos_plataformas? entidad);
        List<Videojuegos_plataformas> ListarPorPlataforma(Videojuegos_plataformas? entidad);
        Videojuegos_plataformas? Guardar(Videojuegos_plataformas? entidad);
        Videojuegos_plataformas? Modificar(Videojuegos_plataformas? entidad);
        Videojuegos_plataformas? Borrar(Videojuegos_plataformas? entidad);
    }
}
