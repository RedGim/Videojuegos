using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class CarritoCompras
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public DateTime FechaModificacIon {  get; set; }
        public bool Estado { get; set; }


        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
        public List<CarritoDetalles>? CarritoDetalles { get; set; }
    }
}
