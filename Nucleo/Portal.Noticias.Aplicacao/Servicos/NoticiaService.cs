using AutoMapper;
using Portal.Noticias.Aplicacao.Interfaces;
using Portal.Noticias.Aplicacao.Models;
using Portal.Noticias.Dominio.Entidades;
using Portal.Noticias.Repositorio.Interfaces;

namespace Portal.Noticias.Aplicacao.Servicos
{
    public class NoticiaService : INoticiaService
    {
        private readonly INoticiaRepositorio _noticiaRepositorio;
        private readonly ITagRepositorio _tagRepositorio;
        private readonly IMapper _mapper;
        private readonly int UsuarioId = 1; //TODO Pegar o usuário logado

        public NoticiaService(INoticiaRepositorio noticiaRepositorio,
            IMapper mapper,
            ITagRepositorio tagRepositorio)
        {
            _noticiaRepositorio = noticiaRepositorio;
            _mapper = mapper;
            _tagRepositorio = tagRepositorio;
        }

        public async Task<NoticiaModel> Salvar(NoticiaModel noticia)
        {
            return noticia.Id == 0
                ? await Criar(noticia)
                : await Atualizar(noticia);

        }

        public async Task DeletarNoticia(int id)
        {
            await _noticiaRepositorio.DeletarNoticia(id);
        }

        public async Task<List<NoticiaModel>> ObterTodas()
        {
            var noticias = await _noticiaRepositorio
                .ObterTodasNoticias();

            return noticias
                .Select(_mapper.Map<NoticiaModel>)
                .ToList();
        }

        public async Task<NoticiaModel> ObterPorId(int id)
        {
            var noticia = await _noticiaRepositorio.ObterPorId(id);
            return _mapper.Map<NoticiaModel>(noticia);
        }

        private void ValidarRegras(NoticiaModel entidade)
        {
            if (entidade.Id > 0 && entidade.UsuarioId != UsuarioId)
                throw new UnauthorizedAccessException("Somente o autor da notícia pode alterar sua própria notícia!");
            if (string.IsNullOrEmpty(entidade.Titulo))
                throw new ArgumentNullException("O título da notícia é obrigatório.");
            if (string.IsNullOrEmpty(entidade.Texto))
                throw new ArgumentNullException("O texto da notícia é obrigatório.");

        }

        private async Task<NoticiaModel> Atualizar(NoticiaModel entidade)
        {
            entidade.UsuarioId = UsuarioId;
            ValidarRegras(entidade);

            var noticiaExistente = await _noticiaRepositorio.ObterPorId(entidade.Id);

            noticiaExistente.Titulo = entidade.Titulo;
            noticiaExistente.Texto = entidade.Texto;
            noticiaExistente.Tags.Clear();

            foreach (var tagId in entidade.TagsIds)
            {
                noticiaExistente.Tags.Add(new NoticiaTag
                {
                    NoticiaId = noticiaExistente.Id,
                    TagId = tagId
                });
            }

            var resposta = await _noticiaRepositorio.AtualizarNoticia(noticiaExistente);
            return _mapper.Map<NoticiaModel>(resposta);
        }

        private async Task<NoticiaModel> Criar(NoticiaModel entidade)
        {
            ValidarRegras(entidade);
            var tags = await _tagRepositorio
                .ObterPorIds(entidade.TagsIds.ToArray());
            var noticia = _mapper.Map<Noticia>(entidade);
            noticia.Tags = tags
                .Select(t => new NoticiaTag { TagId = t.Id })
                .ToList();
            noticia.UsuarioId = UsuarioId;

            var resposta = await _noticiaRepositorio.AdicionarNoticia(noticia);
            return _mapper.Map<NoticiaModel>(resposta);
        }
    }
}
