
using Portal.Noticias.Aplicacao.Models;

namespace Portal.Noticias.Aplicacao.Interfaces
{
    public interface INoticiaService
    {
        Task DeletarNoticia(int id);
        Task<List<NoticiaModel>> ObterTodas();
        Task<NoticiaModel> ObterPorId(int id);
        Task<NoticiaModel> Salvar(NoticiaModel noticia);
    }
}
