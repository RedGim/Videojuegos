using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    internal class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public bool Activo { get; set; }
        public DateTime Fecha_nacimiento { get; set; }
        public List<Usuarios_roles>? Usuarios_roles { get; set; }
    }
}