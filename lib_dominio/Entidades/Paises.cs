namespace lib_dominio.Entidades
{
    public class Paises
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public List<Usuarios>? Usuarios { get; set; }
        public List<Desarrolladores>? Desarrolladores { get; set; }
    }
}
