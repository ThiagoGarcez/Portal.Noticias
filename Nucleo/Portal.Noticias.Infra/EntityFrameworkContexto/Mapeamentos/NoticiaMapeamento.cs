using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Infra.EntityFrameworkContexto.Mapeamentos
{
    public class NoticiaMapeamento : IEntityTypeConfiguration<Noticia>
    {
        public void Configure(EntityTypeBuilder<Noticia> builder)
        {
            builder.HasOne(n => n.Usuario);
            builder.HasMany(n => n.Tags).WithOne(t => t.Noticia);
            builder.Property(n => n.Titulo).HasMaxLength(250).IsRequired();
            builder.Property(n => n.Texto).IsRequired();
        }
    }
}