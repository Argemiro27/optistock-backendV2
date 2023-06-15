using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class ItensNFeMap : IEntityTypeConfiguration<ItensNFeModel>
    {
        public void Configure(EntityTypeBuilder<ItensNFeModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Produto)
                .WithMany()
                .HasForeignKey(x => x.id_produto)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.NFe)
                .WithMany()
                .HasForeignKey(x => x.id_nfe)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.quantidade).IsRequired().HasMaxLength(100);
            builder.Property(x => x.valor_unit).IsRequired().HasMaxLength(100);
            builder.Property(x => x.valor_total_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.icms).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ipi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.pis).IsRequired().HasMaxLength(100);
            builder.Property(x => x.cofins).IsRequired().HasMaxLength(100);
            builder.Property(x => x.iss).IsRequired().HasMaxLength(100);

            builder.Property(x => x.total_icms_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_ipi_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_pis_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_cofins_produto).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_iss_produto).IsRequired().HasMaxLength(100);

        }


    }
}
