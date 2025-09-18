using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVideojuegos_categoriasAplicacion
    {
        void Configurar(string StringConexion);
        List<Videojuegos_categorias> Listar();
        List<Videojuegos_categorias> ListarPorVideojuego(Videojuegos_categorias? entidad);
        List<Videojuegos_categorias> ListarPorCategoria(Videojuegos_categorias? entidad);
        Videojuegos_categorias? Guardar(Videojuegos_categorias? entidad);
        Videojuegos_categorias? Modificar(Videojuegos_categorias? entidad);
        Videojuegos_categorias? Borrar(Videojuegos_categorias? entidad);
    }
}
