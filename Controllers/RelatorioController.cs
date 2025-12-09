using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;

namespace projetodotnnett.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            var produtos = ProdutoController.produtos;

            int totalItens = produtos.Count;
            decimal valorTotal = produtos.Sum(p => p.Quantidade * p.Preco);

            ViewBag.TotalItens = totalItens;
            ViewBag.ValorTotal = valorTotal;

            return View();
        }
    }
}
