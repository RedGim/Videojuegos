using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface IBibliotecasAplicacion
    {
        void Configurar(string StringConexion);

        List<Bibliotecas> Listar();
        List<Bibliotecas> ListarPorVideojuegos(Bibliotecas? entidad);
        List<Bibliotecas> ListarPorUsuario(Bibliotecas? entidad);
        Bibliotecas? Guardar(Bibliotecas? entidad);
        Bibliotecas? Modificar(Bibliotecas? entidad);
        Bibliotecas? Borrar(Bibliotecas? entidad);
    }
}
