using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;
using projetodotnnett.Data; // IMPORTANTE

namespace projetodotnnett.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        // LISTAS ANTIGAS (não usadas mais, mas mantidas pois você pediu)
        public static List<Produto> produtos = new();
        public static List<Movimentacao> movimentacoes = new();

        private static int ultimoId = 1;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        // LISTAR
        public IActionResult Index()
        {
            var lista = _context.Produtos.ToList();
            return View(lista);
        }

        // CADASTRAR - GET
        public IActionResult Criar()
        {
            return View(new Produto());
        }

        // CADASTRAR - POST
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            // GERAR ID (SQLite vai sobrescrever depois, mas você pediu pra manter)
            produto.Id = ultimoId++;

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            // REGISTRA MOVIMENTAÇÃO
            var mov = new Movimentacao
            {
                ProdutoId = produto.Id,
                ProdutoNome = produto.Nome,
                Tipo = "Entrada"
            };

            _context.Movimentacoes.Add(mov);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDITAR - GET
        public IActionResult Editar(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            return View(produto);
        }

        // EDITAR - POST
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var p = _context.Produtos.FirstOrDefault(x => x.Id == produto.Id);

            if (p != null)
            {
                p.Nome = produto.Nome;
                p.Quantidade = produto.Quantidade;
                p.Preco = produto.Preco;

                _context.SaveChanges();

                // REGISTRA MOVIMENTAÇÃO
                var mov = new Movimentacao
                {
                    ProdutoId = p.Id,
                    ProdutoNome = p.Nome,
                    Tipo = "Atualização"
                };

                _context.Movimentacoes.Add(mov);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // EXCLUIR - GET
        public IActionResult Excluir(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);
            return View(produto);
        }

        // EXCLUIR - POST
        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto != null)
            {
                // REGISTRA MOVIMENTAÇÃO
                var mov = new Movimentacao
                {
                    ProdutoId = produto.Id,
                    ProdutoNome = produto.Nome,
                    Tipo = "Saída"
                };

                _context.Movimentacoes.Add(mov);
                _context.SaveChanges();

                _context.Produtos.Remove(produto);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
