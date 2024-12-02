using System.ComponentModel.DataAnnotations;

namespace TccForum.Models.ViewModels
{
    public class AcessoViewModel
    {
        [Required(ErrorMessage = "Nome de usuário/e-mail obrigatório!!")]
        [Display(Name = "Nome de usuário ou e-mail")]
        public string NomeDoUsuarioOuEmail { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!!")]
        public string Senha { get; set; }
    }
}
