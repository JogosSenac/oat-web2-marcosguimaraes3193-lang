using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Data;
using System.Linq;

namespace projetodotnnett.Controllers
{
    public class RelatorioController : Controller
    {
        private readonly AppDbContext _context;

        public RelatorioController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produtos = _context.Produtos.ToList();

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
