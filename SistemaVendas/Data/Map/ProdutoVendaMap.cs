using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class ProdutoVendaMap : IEntityTypeConfiguration<ProdutoVendaModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoVendaModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.id_produto)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Venda)
                .WithMany()
                .HasForeignKey(x => x.id_venda)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.quantidade).IsRequired().HasMaxLength(100);

        }


    }
}
