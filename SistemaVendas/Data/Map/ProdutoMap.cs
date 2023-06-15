using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Marca)
                .WithMany()
                .HasForeignKey(x => x.id_marca)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.cod_barras).IsRequired().HasMaxLength(100);
            builder.Property(x => x.nome_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.preco_venda).IsRequired().HasMaxLength(100);
        }


    }
}
