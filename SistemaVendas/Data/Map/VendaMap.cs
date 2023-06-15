using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class VendaMap : IEntityTypeConfiguration<VendaModel>
    {
        public void Configure(EntityTypeBuilder<VendaModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.HasOne(x => x.Cliente)
                   .WithMany()
                   .HasForeignKey(x => x.id_cliente)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x => x.precototal_venda).IsRequired().HasMaxLength(100);
            builder.Property(x => x.metodo_pagamento).IsRequired().HasMaxLength(100);
        }


    }
}
