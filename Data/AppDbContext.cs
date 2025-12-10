using Microsoft.EntityFrameworkCore;
using projetodotnnett.Models; // Ajuste o namespace

namespace projetodotnnett.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
