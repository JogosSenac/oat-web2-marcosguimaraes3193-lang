using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Data;
using projetodotnnett.Models;

namespace projetodotnnett.Controllers
{
    public class MovimentacaoController : Controller
    {
        private readonly AppDbContext _context;

        public MovimentacaoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // LISTA TODAS AS MOVIMENTAÇÕES DO BANCO
            var lista = _context.Movimentacoes
                .OrderByDescending(m => m.Id)
                .ToList();

            return View(lista);
        }
    }
}
