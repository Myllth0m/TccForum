using Microsoft.AspNetCore.Mvc;
using TccForum.Models.ViewModels;
using TccForum.Services.Pergunta;

namespace TccForum.Controllers
{
    public class PerguntaController : Controller
    {
        private readonly IPerguntaInterface perguntaInterface;

        public PerguntaController(IPerguntaInterface perguntaInterface)
        {
            this.perguntaInterface = perguntaInterface;
        }

        public async Task<IActionResult> Index()
        {
            var perguntas = await perguntaInterface.BuscarTodasAsPerguntas();
            return View(perguntas);
        }

        public IActionResult Cadastrar() => View();

        [HttpPost]
        public async Task<IActionResult> Cadastrar(
            PerguntaCriacaoViewModel perguntaViewModel,
            IFormFile capaDaPergunta)
        {
            await perguntaInterface.CriarPergunta(perguntaViewModel, capaDaPergunta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Editar(int id)
        {
            var pergunta = await perguntaInterface.BuscarPerguntaPorId(id);
            return View(pergunta);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(
            Models.Entities.Pergunta pergunta,
            IFormFile? capaDaPergunta)
        {
            await perguntaInterface.EditarPergunta(pergunta, capaDaPergunta);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Remover(int id)
        {
            await perguntaInterface.RemoverPergunta(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
