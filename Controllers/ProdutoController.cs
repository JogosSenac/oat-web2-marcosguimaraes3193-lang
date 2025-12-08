using Microsoft.AspNetCore.Mvc;
using projetodotnnett.Models;

namespace projetodotnnett.Controllers
{
    public class ProdutoController : Controller
    {
        // Lista em memória (igual login)
        private static List<Produto> produtos = new();
        private static int ultimoId = 1;

        // LISTA
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

            p.Nome = produto.Nome;
            p.Quantidade = produto.Quantidade;
            p.Preco = produto.Preco;

            return RedirectToAction("Index");
        }

        // EXCLUIR - GET (confirmação)
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
            produtos.Remove(produto);

            return RedirectToAction("Index");
        }
    }
}
