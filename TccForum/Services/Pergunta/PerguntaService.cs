using Microsoft.EntityFrameworkCore;
using TccForum.Data;
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

        private string GerarCaminhoDoArquivo(IFormFile capa)
        {
            var dataDaImagem = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "-");
            var caminhoDaImagem = dataDaImagem + "-" + capa.FileName.Trim().Replace(" ", "").ToLower();
            var pastaDeImagens = storage + "\\assets\\";

            if (!Directory.Exists(pastaDeImagens))
                Directory.CreateDirectory(pastaDeImagens);

            using (var stream = File.Create(pastaDeImagens + caminhoDaImagem))
            {
                capa.CopyToAsync(stream).Wait();
            }

            return caminhoDaImagem;
        }

        public async Task<List<Models.Entities.Pergunta>> BuscarTodasAsPerguntas()
        {
            var perguntas = await contexto.Perguntas.ToListAsync();
            return perguntas;
        }

        public async Task CriarPergunta(PerguntaCriacaoViewModel perguntaViewModel, IFormFile capa)
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
        }

        public async Task<Models.Entities.Pergunta> BuscarPerguntaPorId(int id)
        {
            var pergunta = await contexto.Perguntas.FindAsync(id);
            
            return pergunta!;
        }
    }
}
