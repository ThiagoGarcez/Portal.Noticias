using Microsoft.AspNetCore.Mvc;
using Portal.Noticias.Aplicacao.Interfaces;
using Portal.Noticias.Aplicacao.Models;

namespace Portal.Noticias.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IActionResult> Index()
        {
            var tags = await _tagService.ObterTodas();
            return View(tags);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(TagModel entidade)
        {
            try
            {
                var tag = await _tagService.Criar(entidade);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Atualizar(int id)
        {
            var tag = await _tagService.ObterPorId(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Atualizar(TagModel entidade)
        {
            try
            {
                var tag = await _tagService.Atualizar(entidade);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var tag = await _tagService.ObterPorId(id);
            if (tag == null) return NotFound();
            return View(tag);
        }

        [HttpPost, ActionName("Deletar")]
        public async Task<IActionResult> ConfirmarDelete(int id)
        {
            try
            {
                await _tagService.Deletar(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
    }
}