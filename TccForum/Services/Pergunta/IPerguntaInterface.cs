using TccForum.Models.ViewModels;

namespace TccForum.Services.Pergunta
{
    public interface IPerguntaInterface
    {
        Task<List<Models.Entities.Pergunta>> BuscarTodasAsPerguntas();
        Task CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capa);
        Task<Models.Entities.Pergunta> BuscarPerguntaPorId(int id);
    }
}
