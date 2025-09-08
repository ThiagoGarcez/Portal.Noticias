using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Infra.EntityFrameworkContexto.Mapeamentos
{
    public class NoticiaTagMapeamento : IEntityTypeConfiguration<NoticiaTag>
    {
        public void Configure(EntityTypeBuilder<NoticiaTag> builder)
        {
            builder.HasOne(n => n.Noticia);
            builder.HasOne(n => n.Tag);
        }
    }
}