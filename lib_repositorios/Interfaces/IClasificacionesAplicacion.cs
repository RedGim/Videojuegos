using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    internal interface IClasificacionesAplicacion
    {
        void Configurar(string StringConexion);
        List<Clasificaciones> Listar();
        Clasificaciones? Guardar(Clasificaciones? entidad);
        Clasificaciones? Modificar(Clasificaciones? entidad);
        Clasificaciones? Borrar(Clasificaciones? entidad);
    }
}
