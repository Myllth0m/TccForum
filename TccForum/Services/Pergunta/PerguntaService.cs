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

        public async Task<Models.Entities.Pergunta> BuscarPerguntaComRespostasPorId(int id)
        {
            var perguntaComRespostas = await contexto.Perguntas.AsNoTracking().Include(x => x.Respostas).FirstAsync(x => x.Id == id);
            return perguntaComRespostas;
        }

        public async Task<Models.Entities.Pergunta> BuscarPerguntaParaEdicaoPorId(int id)
        {
            var pergunta = await contexto.Perguntas.AsNoTracking().FirstAsync(x => x.Id == id);
            return pergunta!;
        }

        public async Task EditarPergunta(Models.Entities.Pergunta perguntaEditada, IFormFile capaDaPergunta)
        {
            var pergunta = await contexto.Perguntas.AsNoTracking().FirstAsync(x => x.Id == perguntaEditada.Id);
            var caminhoDaImagem = string.Empty;

            if (capaDaPergunta != null)
            {
                var capaDaPerguntaExistente = storage + "\\assets\\" + pergunta.Capa;

                if (File.Exists(capaDaPerguntaExistente))
                    File.Delete(capaDaPerguntaExistente);

                caminhoDaImagem = GerarCaminhoDoArquivo(capaDaPergunta);
            }

            pergunta.Titulo = perguntaEditada.Titulo;
            pergunta.Descricao = perguntaEditada.Descricao;

            if (caminhoDaImagem != string.Empty)
                pergunta.Capa = caminhoDaImagem;
            else
                pergunta.Capa = pergunta.Capa;

            contexto.Perguntas.Update(pergunta);
            await contexto.SaveChangesAsync();
        }

        public async Task RemoverPergunta(int id)
        {
            var pergunta = await contexto.Perguntas.AsNoTracking().FirstAsync(x => x.Id == id);

            if (pergunta.Capa != null)
            {
                var capaDaPerguntaExistente = storage + "\\assets\\" + pergunta.Capa;

                if (File.Exists(capaDaPerguntaExistente))
                    File.Delete(capaDaPerguntaExistente);
            }

            contexto.Perguntas.Remove(pergunta);
            await contexto.SaveChangesAsync();
        }
    }
}
