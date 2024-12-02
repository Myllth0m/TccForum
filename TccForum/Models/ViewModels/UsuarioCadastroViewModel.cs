using System.ComponentModel.DataAnnotations;

namespace TccForum.Models.ViewModels
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Primeiro nome")]
        public string PrimeiroNome { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        [Display(Name = "Último nome")]
        public string UltimoNome { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Nome de usuário obrigatório")]
        [Display(Name = "Nome de usuário")]
        public string NomeDoUsuario { get; set; }

        [Required(ErrorMessage = "Senha obrigatória")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Confirme sua senha")]
        [Compare("Senha", ErrorMessage = "As senhas não estão iguais")]
        [Display(Name = "Confirmar senha")]
        public string ConfirmarSenha { get; set; }

        [Required(ErrorMessage = "Selecione seu tipo de acesso")]
        [Display(Name = "Tipo de usuário")]
        [AllowedValues("UsuarioPadrao", "UsuarioPremium", ErrorMessage = "Tipo de usuário inválido")]
        public string TipoDeUsuario { get; set; }
    }
}
