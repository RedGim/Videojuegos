using lib_dominio.Entidades;

namespace lib_repositorios.Interfaces
{
    public interface ICarritosCompraAplicacion
    {
        void Configurar(string StringConexion);

        List<CarritoCompras> Listar();
        CarritoCompras? Guardar(CarritoCompras? entidad);
        CarritoCompras? Modificar(CarritoCompras? entidad);
        CarritoCompras? Borrar(CarritoCompras? entidad);

        List<CarritoCompras> ListarPorUsuario(CarritoCompras? entidad);
    }
}
