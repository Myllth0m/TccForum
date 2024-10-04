namespace TccForum.Models.Entities
{
    public class Resposta
    {
        public int Id { get; set; }
        public string Conteudo { get; set; }
        public int PerguntaId { get; set; }
        public int? RespostaPaiId { get; set; }
        public List<Resposta> RespostasFilhas { get; set; }
    }
}
