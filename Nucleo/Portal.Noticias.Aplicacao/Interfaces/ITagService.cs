using Portal.Noticias.Aplicacao.Models;

namespace Portal.Noticias.Aplicacao.Interfaces
{
    public interface ITagService
    {
        Task<TagModel> Atualizar(TagModel entidade);
        Task<TagModel> Criar(TagModel entidade);
        Task Deletar(int id);
        Task<List<TagModel>> ObterTodas();
        Task<TagModel> ObterPorId(int id);
    }
}
