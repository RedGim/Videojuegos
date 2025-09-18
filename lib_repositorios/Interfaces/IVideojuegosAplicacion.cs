using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVideojuegosAplicacion
    {
        void Configurar(string StringConexion);
        List<Videojuegos> Listar();
        List<Videojuegos> ListarPorClasificacion(Videojuegos? entidad);
        List<Videojuegos> ListarPorDesarrollador(Videojuegos? entidad);
        Videojuegos? Guardar(Videojuegos? entidad);
        Videojuegos? Modificar(Videojuegos? entidad);
        Videojuegos? Borrar(Videojuegos? entidad);
    }
}