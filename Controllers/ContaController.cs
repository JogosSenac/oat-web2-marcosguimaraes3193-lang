using Microsoft.AspNetCore.Mvc;

namespace projetodotnnett.Controllers
{
    public class ContaController : Controller
    {
        private static List<Usuario> usuarios = new();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var user = usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                ViewBag.Erro = "Credenciais inválidas!";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        // GET: /Conta/Registrar
        public IActionResult Registrar()
        {
            return View();
        }

        // POST: /Conta/Registrar
        [HttpPost]
        public IActionResult Registrar(string nome, string email, string senha)
        {
            usuarios.Add(new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            });

            return RedirectToAction("Login");
        }
    }

    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
