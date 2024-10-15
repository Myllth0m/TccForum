using TccForum.Models.ViewModels;

namespace TccForum.Services.Resposta
{
    public interface IRespostaInterface
    {
        Task CriarResposta(RespostaDaPerguntaCriacaoViewModel respostaDaPergunta);
    }
}
