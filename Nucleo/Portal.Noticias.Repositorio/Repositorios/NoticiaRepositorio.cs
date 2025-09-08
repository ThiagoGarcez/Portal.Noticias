using Microsoft.EntityFrameworkCore;
using Portal.Noticias.Dominio.Entidades;
using Portal.Noticias.Infra.EntityFrameworkContexto;
using Portal.Noticias.Repositorio.Interfaces;

namespace Portal.Noticias.Repositorio.Repositorios
{
    public class NoticiaRepositorio : INoticiaRepositorio
    {
        private readonly PortalNoticiasEFContext _context;

        public NoticiaRepositorio(PortalNoticiasEFContext context)
        {
            _context = context;
        }

        public async Task<Noticia> AdicionarNoticia(Noticia entidade)
        {
            _context.Noticia.Add(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task<List<Noticia>> ObterTodasNoticias()
        {
            return await _context.Noticia.Include(n => n.Tags).ToListAsync();
        }

        public async Task<Noticia> AtualizarNoticia(Noticia entidade)
        {
            _context.Noticia.Update(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public async Task DeletarNoticia(int id)
        {
            var noticia = await ObterPorId(id);
            if (noticia != null)
            {
                _context.Noticia.Remove(noticia);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Noticia> ObterPorId(int id)
        {
            return  await _context.Noticia.FindAsync(id) ?? 
                throw new Exception("Notícia não encontrada");
        }
    }
}
