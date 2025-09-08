using Microsoft.EntityFrameworkCore;
using Portal.Noticias.Dominio.Entidades;
using System.Reflection;

namespace Portal.Noticias.Infra.EntityFrameworkContexto
{
    public class PortalNoticiasEFContext : DbContext
    {
        public PortalNoticiasEFContext(DbContextOptions<PortalNoticiasEFContext> options) 
            : base(options)
        {
            Database.SetCommandTimeout(180);
        }

        public DbSet<Noticia> Noticia { get; set; } = null!;
        public DbSet<Tag> Tag { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
