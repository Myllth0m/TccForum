using Microsoft.AspNetCore.Mvc;

namespace TccForum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
