using Microsoft.EntityFrameworkCore;
using Teste.API.Data.Mappings;
using Teste.API.Models;

namespace Teste.API.Data
{
    public class TesteDbContext : DbContext
    {
        public TesteDbContext(DbContextOptions<TesteDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CompraItem> CompraItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CompraMap());
            modelBuilder.ApplyConfiguration(new CompraItemMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
