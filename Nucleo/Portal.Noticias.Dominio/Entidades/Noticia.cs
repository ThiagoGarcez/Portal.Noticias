namespace Portal.Noticias.Dominio.Entidades
{
    public class Noticia
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public virtual required Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
        public virtual required ICollection<NoticiaTag> Tags { get; set; }
    }
}
