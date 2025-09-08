using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Infra.EntityFrameworkContexto.Mapeamentos
{
    public class TagMapeamento : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(n => n.Descricao).HasMaxLength(100).IsRequired();
        }
    }
}