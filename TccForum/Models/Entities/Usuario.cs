﻿namespace TccForum.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string PrimeiroNome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Escopo { get; set; }

        public List<Pergunta>? Perguntas { get; set; }
        
        public List<Resposta>? Respostas { get; set; }
    }
}
