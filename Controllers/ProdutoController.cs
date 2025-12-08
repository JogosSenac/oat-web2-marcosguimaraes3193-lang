using Microsoft.AspNetCore.Mvc;

namespace projetodotnnett.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
