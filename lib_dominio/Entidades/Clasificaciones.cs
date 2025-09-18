using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Clasificaciones
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int Edad { get; set; }

        public List<Videojuegos>? Videojuegos;
    }
}
