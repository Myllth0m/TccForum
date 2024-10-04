namespace TccForum.Models.Entities
{
    public class Pergunta
    {
        public int Id { get; set; }
        public string Capa { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public List<Resposta> Respostas { get; set; }
    }
}
