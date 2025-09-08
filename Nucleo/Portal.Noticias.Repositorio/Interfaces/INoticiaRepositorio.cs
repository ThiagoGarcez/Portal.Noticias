using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Repositorio.Interfaces
{
    public interface INoticiaRepositorio
    {
        Task<Noticia> AdicionarNoticia(Noticia entidade);
        Task<Noticia> AtualizarNoticia(Noticia entidade);
        Task DeletarNoticia(int id);
        Task<Noticia> ObterPorId(int id);
        Task<List<Noticia>> ObterTodasNoticias();
    }
}