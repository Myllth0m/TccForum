using TccForum.Models.ViewModels;

namespace TccForum.Services.Pergunta
{
    public interface IPerguntaInterface
    {
        Task<Models.Entities.Pergunta> CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capa);
    }
}
