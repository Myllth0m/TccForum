using System.Security.Claims;
using TccForum.Data;
using TccForum.Models.ViewModels;

namespace TccForum.Services.Resposta
{
    public class RespostaService : IRespostaInterface
    {
        private readonly ClaimsPrincipal usuario;
        private readonly AppDbContext contexto;

        public RespostaService(
            IHttpContextAccessor httpContextAccessor,
            AppDbContext contexto)
        {
            this.usuario = httpContextAccessor.HttpContext!.User;
            this.contexto = contexto;
        }

        public async Task CriarResposta(RespostaDaPerguntaCriacaoViewModel respostaDaPergunta)
        {
            var novaRespostaDaPergunta = new Models.Entities.Resposta()
            {
                UsuarioId = int.Parse(usuario.FindFirst("usuarioId")!.Value),
                PerguntaId = respostaDaPergunta.PerguntaId,
                Conteudo = respostaDaPergunta.Conteudo,
            };

            contexto.Respostas.Add(novaRespostaDaPergunta);
            await contexto.SaveChangesAsync();
        }
    }
}
