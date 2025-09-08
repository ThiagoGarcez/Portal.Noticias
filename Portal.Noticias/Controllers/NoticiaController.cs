using Microsoft.AspNetCore.Mvc;
using Portal.Noticias.Aplicacao.Interfaces;
using Portal.Noticias.Aplicacao.Models;

namespace Portal.Noticias.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly INoticiaService _noticiaService;
        private readonly ITagService _tagService;

        public NoticiaController(INoticiaService noticiaService,
            ITagService tagService)
        {
            _noticiaService = noticiaService;
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var noticias = await _noticiaService.ObterTodas();
            return View(noticias);
        }

        public async Task<IActionResult> Adicionar()
        {
            var tags = await _tagService.ObterTodas();
            ViewBag.Tags = tags ?? []; ;

            var model = new NoticiaModel();
            return View(model);
        }

        public async Task<IActionResult> Atualizar(int id)
        {
            var tags = await _tagService.ObterTodas();
            ViewBag.Tags = tags ?? []; ;
            var noticia = await _noticiaService.ObterPorId(id);
            if (noticia == null) return NotFound();
            return View(noticia);
        }

        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] NoticiaModel noticia)
        {
            try
            {
                await _noticiaService.Salvar(noticia);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                await _noticiaService.DeletarNoticia(id);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}
