using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Portal.Noticias.Aplicacao.Interfaces;
using Portal.Noticias.Aplicacao.Servicos;
using Portal.Noticias.Infra.EntityFrameworkContexto;
using Portal.Noticias.Repositorio.Interfaces;
using Portal.Noticias.Repositorio.Repositorios;

namespace Portal.Noticias.IoC
{
    public static class DependencyInjection
    {
        public static void AdicionarDependencias(this IServiceCollection services,
            IConfiguration configuration)
        {

            Aplicacao(services);
            Repositorio(services);
            Infra(services, configuration);
            ConfigurarAutoMapper(services);
        }

        private static void ConfigurarAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(Aplicacao.IAssemblyMarker).Assembly);
        }

        private static void Infra(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<PortalNoticiasEFContext>(options =>
                options.UseSqlServer(connectionString,
                    providerOptions => providerOptions.EnableRetryOnFailure()));
        }

        private static void Repositorio(IServiceCollection services)
        {
            services.AddScoped<INoticiaRepositorio, NoticiaRepositorio>();
            services.AddScoped<ITagRepositorio, TagRepositorio>();
        }

        private static void Aplicacao(IServiceCollection services)
        {
            services.AddScoped<INoticiaService, NoticiaService>();
            services.AddScoped<ITagService, TagService>();
        }
    }
}
