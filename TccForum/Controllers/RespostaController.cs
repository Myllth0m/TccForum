using Microsoft.AspNetCore.Mvc;
using TccForum.Models.ViewModels;

namespace TccForum.Controllers
{
    public class RespostaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RespostaDaPerguntaCriacaoViewModel respostaDaPerguntaCriacaoViewModel)
        {
            return View();
        }
    }
}
