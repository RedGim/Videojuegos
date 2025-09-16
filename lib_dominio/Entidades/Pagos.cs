using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public int Usuario {  get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
        public DateTime Fecha { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
