using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? contraseña { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public int Pais { get; set; }

        [ForeignKey("Pais")] public Paises? _Paises { get; set; }
    }
}