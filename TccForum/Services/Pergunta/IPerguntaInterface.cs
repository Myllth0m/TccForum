using TccForum.Models.ViewModels;

namespace TccForum.Services.Pergunta
{
    public interface IPerguntaInterface
    {
        Task<List<Models.Entities.Pergunta>> BuscarTodasAsPerguntas();
        Task CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capaDaPergunta);
        Task<Models.Entities.Pergunta> BuscarPerguntaPorId(int id);
        Task EditarPergunta(Models.Entities.Pergunta pergunta, IFormFile capaDaPergunta);
        Task RemoverPergunta(int id);
    }
}
