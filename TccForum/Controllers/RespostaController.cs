using Microsoft.AspNetCore.Mvc;
using TccForum.Models.ViewModels;
using TccForum.Services.Resposta;

namespace TccForum.Controllers
{
    public class RespostaController : Controller
    {
        private readonly IRespostaInterface respostaInterface;

        public RespostaController(IRespostaInterface respostaInterface)
        {
            this.respostaInterface = respostaInterface;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RespostaDaPerguntaCriacaoViewModel respostaDaPerguntaCriacaoViewModel)
        {
            await respostaInterface.CriarResposta(respostaDaPerguntaCriacaoViewModel);
            return RedirectToAction("Detalhar", "Pergunta", new { Id = respostaDaPerguntaCriacaoViewModel.PerguntaId });
        }
    }
}
