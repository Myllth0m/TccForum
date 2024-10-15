using TccForum.Models.ViewModels;

namespace TccForum.Services.Pergunta
{
    public interface IPerguntaInterface
    {
        Task<List<Models.Entities.Pergunta>> BuscarTodasAsPerguntas();
        Task CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capaDaPergunta);
        Task<Models.Entities.Pergunta> BuscarPerguntaComRespostasPorId(int id);
        Task<Models.Entities.Pergunta> BuscarPerguntaParaEdicaoPorId(int id);
        Task EditarPergunta(Models.Entities.Pergunta pergunta, IFormFile capaDaPergunta);
        Task RemoverPergunta(int id);
    }
}
