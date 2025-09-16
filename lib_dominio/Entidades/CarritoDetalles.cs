using System.ComponentModel.DataAnnotations.Schema;

namespace lib_dominio.Entidades
{
    public class CarritoDetalles
    {
        public int Id { get; set; }
        public int Carrito { get; set; }
        public int VideoJuego { get; set; }
        public int Cantidad { get; set;}
        public decimal Precio { get; set;}

        [ForeignKey("Carrito")] public CarritoCompras? CarritoCompras { get; set; }
        [ForeignKey("VideoJuego")] public Videojuegos? Videojuegos { get; set; }
    }
}
