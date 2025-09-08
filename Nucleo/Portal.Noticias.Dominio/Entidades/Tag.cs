namespace Portal.Noticias.Dominio.Entidades
{
    public class Tag
    {
        public int Id { get; set; }
        public required string Descricao { get; set; }
        public virtual ICollection<NoticiaTag>? Noticias { get; set; }
    }
}
