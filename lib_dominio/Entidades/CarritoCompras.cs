using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class CarritoCompras
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime FechaModificacIon {  get; set; }
        public bool Estado { get; set; }


        public List<CarritoDetalles>? CarritoDetalles;
        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
