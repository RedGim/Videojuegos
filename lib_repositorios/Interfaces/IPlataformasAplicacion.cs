using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    internal interface IPlataformasAplicacion
    {
        void Configurar(string StringConexion);
        List<Plataformas> Listar();
        Plataformas? Guardar(Plataformas? entidad);
        Plataformas? Modificar(Plataformas? entidad);
        Plataformas? Borrar(Plataformas? entidad);
    }
}
