using TccForum.Data;
using TccForum.Models.Entities;
using TccForum.Models.ViewModels;

namespace TccForum.Services.Pergunta
{
    public class PerguntaService : IPerguntaInterface
    {
        private readonly AppDbContext contexto;
        private readonly string storage;

        public PerguntaService(AppDbContext contexto, IWebHostEnvironment storage)
        {
            this.contexto = contexto;
            this.storage = storage.WebRootPath;
        }

        public async Task<Models.Entities.Pergunta> CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capa)
        {
            var caminhoDaImagem = GerarCaminhoDoArquivo(capa);
            var novaPergunta = new Models.Entities.Pergunta
            {
                Capa = caminhoDaImagem,
                Titulo = perguntaViewModel.Titulo,
                Descricao = perguntaViewModel.Descricao,
                Respostas = []
            };

            contexto.Add(novaPergunta);
            await contexto.SaveChangesAsync();

            return novaPergunta;
        }

        private string GerarCaminhoDoArquivo(IFormFile capa)
        {
            var codigoUnico = Guid.NewGuid().ToString();
            var caminhoDaImagem = capa.FileName.Replace(" ", "").ToLower() + codigoUnico + ".png";
            var pastaDeImagens = storage + "\\assets\\";

            if (!Directory.Exists(pastaDeImagens))
                Directory.CreateDirectory(pastaDeImagens);

            using (var stream = File.Create(pastaDeImagens + caminhoDaImagem))
            {
                capa.CopyToAsync(stream).Wait();
            }

            return caminhoDaImagem;
        }
    }
}
