using TccForum.Data;
using TccForum.Models.ViewModels;

namespace TccForum.Services.Resposta
{
    public class RespostaService : IRespostaInterface
    {
        private readonly AppDbContext contexto;

        public RespostaService(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task CriarResposta(RespostaDaPerguntaCriacaoViewModel respostaDaPergunta)
        {
            var novaRespostaDaPergunta = new Models.Entities.Resposta()
            {
                Conteudo = respostaDaPergunta.Conteudo,
                PerguntaId = respostaDaPergunta.PerguntaId,
            };

            contexto.Respostas.Add(novaRespostaDaPergunta);
            await contexto.SaveChangesAsync();
        }
    }
}
