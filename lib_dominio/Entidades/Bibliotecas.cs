using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Bibliotecas
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int VideoJuego { get; set; }
        public DateTime FechaAdquisicion { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("VideoJuego")] public Videojuegos? _Videojuego { get; set; }

    }
}
