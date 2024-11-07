namespace TccForum.Models.Entities
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        public int PerguntaId { get; set; }
        public Pergunta Pergunta { get; set; }
        
        public int? RespostaPaiId { get; set; }
        public Resposta RespostaPai { get; set; }

        public List<Resposta> RespostasFilhas { get; set; }
    }
}
