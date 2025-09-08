using AutoMapper;
using Portal.Noticias.Aplicacao.Interfaces;
using Portal.Noticias.Aplicacao.Models;
using Portal.Noticias.Dominio.Entidades;
using Portal.Noticias.Repositorio.Interfaces;

namespace Portal.Noticias.Aplicacao.Servicos
{
    public class TagService : ITagService
    {
        private readonly ITagRepositorio _tagRepositorio;
        private readonly IMapper _mapper;

        public TagService(ITagRepositorio tagRepositorio, 
            IMapper mapper)
        {
            _tagRepositorio = tagRepositorio;
            _mapper = mapper;
        }

        public async Task<TagModel> Atualizar(TagModel entidade)
        {
            var tag = _mapper.Map<Tag>(entidade);
            var resposta = await _tagRepositorio.Atualizar(tag);
            return _mapper.Map<TagModel>(resposta);
        }

        public async Task<TagModel> Criar(TagModel entidade)
        {
            var tag = _mapper.Map<Tag>(entidade);
            var resposta = await _tagRepositorio.Adicionar(tag);
            return _mapper.Map<TagModel>(resposta);
        }

        public async Task Deletar(int id)
        {
            await _tagRepositorio.Deletar(id);
        }

        public async Task<TagModel> ObterPorId(int id)
        {
            var tag = await _tagRepositorio.ObterPorId(id);
            return _mapper.Map<TagModel>(tag); ;
        }

        public async Task<List<TagModel>> ObterTodas()
        {
            var tags = await _tagRepositorio
                .ObterTodas();

            return tags
                .Select(_mapper.Map<TagModel>)
                .ToList();
        }
    }
}
