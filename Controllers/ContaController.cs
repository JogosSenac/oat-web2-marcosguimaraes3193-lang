using Microsoft.AspNetCore.Mvc;

namespace projetodotnnett.Controllers
{
    public class ContaController : Controller
    {
        // GET: /Conta/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Conta/Login
        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            if (email == "admin@admin.com" && senha == "123")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Credenciais incorretas!";
            return View();
        }
    }
}
