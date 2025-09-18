using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Videojuegos_plataformas
    {
        public int Id { get; set; }
        public int Videojuego { get; set; }
        public int Plataforma { get; set; }

        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }
        [ForeignKey("Plataforma")] public Plataformas? _Plataforma { get; set; }
    }
}