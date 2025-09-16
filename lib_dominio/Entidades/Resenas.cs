using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Resenas
    {
        public int Id { get; set; }
        public int Usuario {  get; set; }
        public int VideoJuego { get; set; }
        public decimal Calificacion {  get; set; }
        public string? Comentario { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        [ForeignKey("VideoJuego")] public Videojuegos? _Videojuego { get; set; }
    }
}
