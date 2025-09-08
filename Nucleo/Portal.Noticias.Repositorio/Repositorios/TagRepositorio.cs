using Microsoft.EntityFrameworkCore;
using Portal.Noticias.Dominio.Entidades;
using Portal.Noticias.Infra.EntityFrameworkContexto;
using Portal.Noticias.Repositorio.Interfaces;
using System.Diagnostics;

namespace Portal.Noticias.Repositorio.Repositorios
{
    public class TagRepositorio : ITagRepositorio
    {
        private readonly PortalNoticiasEFContext _context;

        public TagRepositorio(PortalNoticiasEFContext context)
        {
            _context = context;
        }

        public async Task<Tag> Adicionar(Tag entidade)
        {
            _context.Tag.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<List<Tag>> ObterTodas()
        {
            return await _context.Tag.ToListAsync();
        }

        public async Task<Tag> Atualizar(Tag entidade)
        {
            _context.Tag.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task Deletar(int id)
        {
            var tag = await ObterPorId(id);
            if (tag != null)
            {
                _context.Tag.Remove(tag);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Tag> ObterPorId(int id)
        {
            return await _context.Tag.FindAsync(id) ?? throw new Exception("Tag não encontrada");
        }

        public async Task<ICollection<Tag>> ObterPorIds(params int[] tagsIds)
        {
            return await _context.Tag.Where(t => tagsIds.Contains(t.Id)).ToListAsync();
        }
    }
}