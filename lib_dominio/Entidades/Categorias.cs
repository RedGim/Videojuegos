namespace lib_dominio.Entidades
{
    public class Categorias
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public List<Videojuegos_categorias>? Videojuegos_categorias;
    }
}

