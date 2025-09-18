using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public int Pais { get; set; }

        public List<Bibliotecas>? Bibliotecas { get; set; }
        public List<Pagos>? Pagos { get; set; }
        public List<Resenas>? Resenas { get; set; }
        public List<Usuarios_roles>? Usuarios_roles { get; set; }
        public List<CarritoCompras>? CarritoCompras { get; set; }

        [ForeignKey("Pais")] public Paises? _Paises { get; set; }
    }
}