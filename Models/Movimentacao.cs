 namespace projetodotnnett.Models

{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string ProdutoNome { get; set; }
        public int ProdutoId { get; set; }
        public string Tipo { get; set; } // Entrada / Atualização / Saída
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
