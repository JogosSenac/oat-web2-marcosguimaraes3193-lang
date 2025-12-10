using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Data;
using projetodotnnett.Models;
using Microsoft.EntityFrameworkCore;

namespace projetodotnnett.Controllers
{
    public class ContaController : Controller
    {
        private readonly AppDbContext _context;

        public ContaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (user == null)
            {
                ViewBag.Erro = "Credenciais inválidas!";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string nome, string email, string senha)
        {
            var novoUsuario = new Usuario
            {
                Nome = nome,
                Email = email,
                Senha = senha
            };

            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }
    }
}
