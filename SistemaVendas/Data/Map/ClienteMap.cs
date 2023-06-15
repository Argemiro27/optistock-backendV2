using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVendas.Models;

namespace SistemaVendas.Data.Map
{
    public class ClienteMap : IEntityTypeConfiguration<ClienteModel>
    {
        public void Configure(EntityTypeBuilder<ClienteModel> builder)
        {
            builder.HasKey(x => x.id);
            builder.Property(x => x.nome).IsRequired().HasMaxLength(100);
            builder.Property(x => x.email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.telefone).IsRequired().HasMaxLength(100);
        }


    }
}
