using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Paises? Paises()
        {
            var entidad = new Paises();
            entidad.Nombre = "Colombiaa";
            return entidad;
        }
        public static Bibliotecas? Bibliotecas()
        {
            var biblioteca = new Bibliotecas();

            biblioteca.Usuario = 1;
            biblioteca.VideoJuego = 2;
            biblioteca.FechaAdquisicion = DateTime.Now;

            return biblioteca;
        }

        public static Resenas? Resenas()
        {
            var resenas = new Resenas();

            resenas.Usuario = 1;
            resenas.VideoJuego = 3;
            resenas.Calificacion = 3.5m;
            resenas.Comentario = "Este juego ta bueno";
            resenas.Fecha = DateTime.Now;

            return resenas;
        }

        public static CarritoCompras? CarritoCompras()
        {
            var carritoCompra = new CarritoCompras();
            carritoCompra.Usuario = 5;
            carritoCompra.FechaModificacIon = DateTime.Now;
            carritoCompra.Estado = true;
            return carritoCompra;
        }

        public static CarritoDetalles? CarritoDetalles()
        {
            var carritoDetalle = new CarritoDetalles();
            carritoDetalle.Carrito = 2;
            carritoDetalle.VideoJuego = 3;
            carritoDetalle.Cantidad = 2;
            carritoDetalle.Precio = 10.60m;
            return carritoDetalle;
        }

        public static Pagos? Pagos()
        {
            var pago = new Pagos();
            pago.Usuario = 3;
            pago.Monto = 20.35m;
            pago.MetodoPago = "Tarjeta de crédito";
            pago.Fecha = DateTime.Now;
            return pago;
        }

        public static Plataformas? Plataformas()
        {
            var entidad = new Plataformas();
            entidad.Nombre = "Prueba";
            return entidad;
        }

        public static Roles? Roles()
        {
            var entidad = new Roles();
            entidad.Nombre = "Prueba";
            entidad.Activo = false;
            return entidad;
        }

        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
            entidad.Nombre = "Prueba";
            entidad.Descripcion = "Prueba";
            return entidad;
        }
        public static Clasificaciones? Clasificaciones()
        {
            var entidad = new Clasificaciones();
            entidad.Nombre = "Prueba";
            entidad.Edad = 20;
            return entidad;
        }
        public static Usuarios_roles? Usuarios_roles()
        {
            var entidad = new Usuarios_roles();
            entidad.Usuario = 1;
            entidad.Rol = 1;
            return entidad;
        }
        public static Perfiles? Perfiles()
        {
            var entidad = new Perfiles();
            entidad.Nickname = "Prueba";
            entidad.Biografia = "Prueba";
            entidad.Usuario = 1;
            return entidad;
        }
        public static Videojuegos? Videojuegos()
        {
            var entidad = new Videojuegos();
            entidad.Nombre = "Prueba";
            entidad.Descripcion = "Prueba";
            entidad.Valor = 10.111m;
            entidad.FechaLanzamiento = DateTime.Now;
            entidad.clasificacion = 1;
            entidad.Desarrollador = 1;
            return entidad;
        }
        public static Usuarios? Usuarios()
        {
            var entidad = new Usuarios();
            entidad.Nombre = "Prueba";
            entidad.Correo = "Prueba@prueba";
            entidad.Contrasena = "1234";
            entidad.Fecha_nacimiento = DateTime.Now;
            entidad.Pais = 1;
            return entidad;
        }



        public static Clasificaciones? Clasificaciones()
        {
            var entidad = new Clasificaciones();
            return entidad;
        }

        public static Desarrolladores? Desarrolladores()
        {
            var entidad = new Desarrolladores();
            return entidad;
        }
    }
}