using Portal.Noticias.Dominio.Entidades;

namespace Portal.Noticias.Repositorio.Interfaces
{
    public interface ITagRepositorio
    {
        Task<Tag> Adicionar(Tag entidade);
        Task<Tag> Atualizar(Tag entidade);
        Task Deletar(int id);
        Task<Tag> ObterPorId(int id);
        Task<ICollection<Tag>> ObterPorIds(params int[] tagsIds);
        Task<List<Tag>> ObterTodas();
    }
}
