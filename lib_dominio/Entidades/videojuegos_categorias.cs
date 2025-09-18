using System.ComponentModel.DataAnnotations.Schema;
namespace lib_dominio.Entidades
{
    public class Videojuegos_categorias
    {
        public int Id { get; set; }
        public int Videojuego { get; set; }
        public int Categoria { get; set; }

        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
    }
}
