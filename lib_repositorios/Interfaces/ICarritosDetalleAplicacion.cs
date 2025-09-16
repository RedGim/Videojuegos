using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ICarritosDetalleAplicacion
    {
        void Configurar(string StringConexion);

        List<CarritoDetalles> Listar();
        CarritoDetalles? Guardar(CarritoDetalles? entidad);
        CarritoDetalles? Modificar(CarritoDetalles? entidad);
        CarritoDetalles? Borrar(CarritoDetalles? entidad);
    }
}
