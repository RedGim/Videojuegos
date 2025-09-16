using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Usuarios_roles
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public int Rol { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuarios { get; set; }
        [ForeignKey("Rol")] public Roles? _Roles { get; set; }
    }
}
