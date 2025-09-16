using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_creacion { get; set; } = DateTime.Now;
    }
}