using Microsoft.AspNetCore.Mvc;

namespace projetodotnnett.Controllers
{
    public class EstoqueController : Controller
    {
        public IActionResult Movimentacao()
        {
            return View();
        }

        public IActionResult Relatorio()
        {
            return View();
        }
    }
}
