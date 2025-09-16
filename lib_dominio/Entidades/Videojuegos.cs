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

        [ForeignKey("clasificacion")] public Clasificaciones? _Clasificacion { get; set; }
        [ForeignKey("Desarrollador")] public Desarrolladores? _Desarrollador { get; set; }

    }
}