using Microsoft.EntityFrameworkCore;
using SistemaVendas.Data.Map;
using SistemaVendas.Models;

namespace SistemaVendas.Data
{
    public class SistemaVendasDBContext : DbContext
    {
        public SistemaVendasDBContext(DbContextOptions<SistemaVendasDBContext> options) : base(options)
        {
            
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<ClienteModel> Clientes { get; set; }
        public DbSet<DistribuidoraModel> Distribuidoras { get; set; }
        public DbSet<MarcaModel> Marcas { get; set; }
        public DbSet<NFeModel> NFes { get; set; }
        public DbSet<ItensNFeModel> ItensNFes { get; set; }
        public DbSet<ProdutoVendaModel> ProdutoVendas { get; set; }
        public DbSet<VendaModel> Vendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
