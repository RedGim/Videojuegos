using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class Desarrolladores
    {

        public int Id { get; set; }
        public string? Nombre_estudio { get; set; }
        public int Pais { get; set; }
        public string? web { get; set; }

        [ForeignKey("Pais")] public Paises? _Pais { get; set; }
    }
}
