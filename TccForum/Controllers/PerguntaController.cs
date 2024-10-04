using Microsoft.AspNetCore.Mvc;
using TccForum.Data;
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

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
