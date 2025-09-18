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

        public List<Bibliotecas>? Bibliotecas;
        public List<Pagos>? Pagos;
        public List<Resenas>? Resenas;
        public List<Usuarios_roles>? Usuarios_roles;
        public List<CarritoCompras>? CarritoCompras;
        [ForeignKey("Pais")] public Paises? _Paises { get; set; }
    }
}