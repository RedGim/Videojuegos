using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IVideojuegosAplicacion
    {
        void Configurar(string StringConexion);
        List<Videojuegos> Listar();
        Videojuegos? Guardar(Videojuegos? entidad);
        Videojuegos? Modificar(Videojuegos? entidad);
        Videojuegos? Borrar(Videojuegos? entidad);
    }
}