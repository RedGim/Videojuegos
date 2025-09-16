using lib_dominio.Entidades;

namespace ut_presentacion.Nucleo
{
    public class EntidadesNucleo
    {
        public static Paises? Paises()
        {
            var entidad = new Paises();
            //entidad.Nombre
            return entidad;
        }

        public static Plataformas? Plataformas() 
        {
            var entidad = new Plataformas();
            entidad.Nombre = "Prueba";
            return entidad;
        }

        public static Categorias? Categorias()
        {
            var entidad = new Categorias();
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