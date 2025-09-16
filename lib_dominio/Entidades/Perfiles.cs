using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Perfiles
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string? Biografia { get; set; }
        public int Usuario { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuarios { get; set; }
    }
}