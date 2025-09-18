using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Videojuegos
    {
		public int Id { get; set; }
		public string? Nombre { get; set; }
		public string? Descripcion { get; set; }
		public decimal Valor { get; set; }
		public DateTime FechaLanzamiento { get; set; }
		public int clasificacion { get; set; }
        public int Desarrollador { get; set; }

        public List<Bibliotecas>? Bibliotecas;
        public List<CarritoDetalles>? CarritoDetalles;
        public List<Resenas>? Resenas;
        public List<Videojuegos_plataformas>? Videojuegos_plataformas;
        public List<Videojuegos_categorias>? Videojuegos_categorias;
        [ForeignKey("clasificacion")] public Clasificaciones? _Clasificacion { get; set; }
        [ForeignKey("Desarrollador")] public Desarrolladores? _Desarrollador { get; set; }

    }
}