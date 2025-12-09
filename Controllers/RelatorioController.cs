using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;
using System.Linq;

namespace projetodotnnett.Controllers
{
    public class RelatorioController : Controller
    {
        public IActionResult Index()
        {
            var produtos = ProdutoController.produtos;

            // Soma REAL do estoque
            int totalItens = produtos.Sum(p => p.Quantidade);

            // Soma total em dinheiro
            decimal valorTotal = produtos.Sum(p => p.Quantidade * p.Preco);

            ViewBag.TotalItens = totalItens;
            ViewBag.ValorTotal = valorTotal;

            return View();
        }
    }
}
