namespace lib_dominio.Entidades
{
    public class Plataformas
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public List<Videojuegos_plataformas>? Videojuegos_plataformas { get; set; }
    }

}