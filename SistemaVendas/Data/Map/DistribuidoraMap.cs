using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class DistribuidoraMap : IEntityTypeConfiguration<DistribuidoraModel>
    {
        public void Configure(EntityTypeBuilder<DistribuidoraModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome_distribuidora).IsRequired().HasMaxLength(100);
            builder.Property(x => x.cep).IsRequired().HasMaxLength(100);
            builder.Property(x => x.email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.cnpj).IsRequired().HasMaxLength(100);
            builder.Property(x => x.telefone).IsRequired().HasMaxLength(100);

        }


    }
}
