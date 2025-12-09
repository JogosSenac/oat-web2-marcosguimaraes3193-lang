using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;

namespace projetodotnnett.Controllers
{
    public class MovimentacaoController : Controller
    {
        public IActionResult Index()
        {
            return View(ProdutoController.movimentacoes);
        }
    }
}
