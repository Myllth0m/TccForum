using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TccForum.Data;
using TccForum.Models.Entities;
using TccForum.Models.ViewModels;

namespace TccForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext context;

        public AccountController(AppDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Usuarios.ToList());
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(UsuarioCadastroViewModel usuarioCadastroViewModel)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = new Usuario
                {
                    PrimeiroNome = usuarioCadastroViewModel.PrimeiroNome,
                    UltimoNome = usuarioCadastroViewModel.UltimoNome,
                    Email = usuarioCadastroViewModel.Email,
                    Login = usuarioCadastroViewModel.NomeDoUsuario,
                    Senha = usuarioCadastroViewModel.Senha,
                    Escopo = usuarioCadastroViewModel.TipoDeUsuario,
                };

                context.Usuarios.Add(usuario);
                context.SaveChanges();

                ModelState.Clear();
                ViewBag.CadastradoComSucesso = $"{usuario.PrimeiroNome} {usuario.UltimoNome} registrado!! Por favor faça o login.";

                return View();
            }

            return View(usuarioCadastroViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(AcessoViewModel acessoViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = context.Usuarios.Where(x => (x.Login == acessoViewModel.NomeDoUsuarioOuEmail || x.Email == acessoViewModel.NomeDoUsuarioOuEmail) && x.Senha == acessoViewModel.Senha).FirstOrDefault();

                if (usuario != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, usuario.PrimeiroNome + " " + usuario.UltimoNome),
                    };

                    if (usuario.Escopo == "UsuarioPadrao")
                        claims.Add(new Claim(ClaimTypes.Role, "UsuarioPadrao"));
                    else
                        claims.Add(new Claim(ClaimTypes.Role, "UsuarioPremium"));

                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies.Forum");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Pergunta");
                }
            }

            return View(acessoViewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }
    }
}
