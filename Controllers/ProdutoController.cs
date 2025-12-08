using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;

namespace projetodotnnett.Controllers
{
    public class ProdutoController : Controller
    {
        // LISTAS EM MEMÓRIA
        public static List<Produto> produtos = new();
        public static List<Movimentacao> movimentacoes = new();

        private static int ultimoId = 1;

        // LISTAR
        public IActionResult Index()
        {
            return View(produtos);
        }

        // CADASTRAR - GET
        public IActionResult Criar()
        {
            return View();
        }

        // CADASTRAR - POST
        [HttpPost]
        public IActionResult Criar(Produto produto)
        {
            produto.Id = ultimoId++;
            produtos.Add(produto);

            // REGISTRA MOVIMENTAÇÃO
            movimentacoes.Add(new Movimentacao
            {
                ProdutoId = produto.Id,
                ProdutoNome = produto.Nome,
                Tipo = "Entrada"
            });

            return RedirectToAction("Index");
        }

        // EDITAR - GET
        public IActionResult Editar(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            return View(produto);
        }

        // EDITAR - POST
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            var p = produtos.FirstOrDefault(x => x.Id == produto.Id);

            if (p != null)
            {
                p.Nome = produto.Nome;
                p.Quantidade = produto.Quantidade;
                p.Preco = produto.Preco;

                // REGISTRA MOVIMENTAÇÃO
                movimentacoes.Add(new Movimentacao
                {
                    ProdutoId = p.Id,
                    ProdutoNome = p.Nome,
                    Tipo = "Atualização"
                });
            }

            return RedirectToAction("Index");
        }

        // EXCLUIR - GET
        public IActionResult Excluir(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);
            return View(produto);
        }

        // EXCLUIR - POST
        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            var produto = produtos.FirstOrDefault(p => p.Id == id);

            if (produto != null)
            {
                // REGISTRA MOVIMENTAÇÃO
                movimentacoes.Add(new Movimentacao
                {
                    ProdutoId = produto.Id,
                    ProdutoNome = produto.Nome,
                    Tipo = "Saída"
                });

                produtos.Remove(produto);
            }

            return RedirectToAction("Index");
        }
    }
}
