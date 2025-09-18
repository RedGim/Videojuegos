using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Desarrolladores
    {

        public int Id { get; set; }
        public string? NombreEstudio { get; set; }
        public int Pais { get; set; }
        public string? web { get; set; }

        public List<Videojuegos>? Videojuegos;
        [ForeignKey("Pais")] public Paises? _Pais { get; set; }
    }
}
