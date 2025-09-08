using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Infra.EntityFrameworkContexto.Mapeamentos
{
    internal class UsuarioMapeamento : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(n => n.Nome).HasMaxLength(250).IsRequired();
            builder.Property(n => n.Senha).HasMaxLength(50).IsRequired();
            builder.Property(n => n.Email).HasMaxLength(250).IsRequired();
        }
    }
}