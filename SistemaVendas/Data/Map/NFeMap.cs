using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class NFeMap : IEntityTypeConfiguration<NFeModel>
    {
        public void Configure(EntityTypeBuilder<NFeModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Distribuidora)
                .WithMany()
                .HasForeignKey(x => x.id_distribuidora)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.num_nfe).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_icms).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_ipi).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_pis).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_cofins).IsRequired().HasMaxLength(100);
            builder.Property(x => x.total_iss).IsRequired().HasMaxLength(100);
            builder.Property(x => x.valortotal_nfe).IsRequired().HasMaxLength(100);
        }


    }
}
