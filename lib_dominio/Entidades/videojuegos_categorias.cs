using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Entidades
{
    internal class videojuegos_categorias
    {
        public int Id { get; set; }
        public int Videojuego { get; set; }
        public int Categoria { get; set; }

        [ForeignKey("Videojuego")] public Videojuegos? _Videojuego { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }
    }
}
