using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchitectureAspNetCoreEFMySQL.Core.Domain.Mappings
{
    public class CarroMap : IEntityTypeConfiguration<Entities.Carro>
    {
        public void Configure(EntityTypeBuilder<Entities.Carro> builder)
        {
            builder.ToTable("Carros");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Marca).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Modelo).HasMaxLength(50).IsRequired();
            builder.Property(c => c.Cor).HasMaxLength(50).IsRequired();
            builder.Property(c => c.AnoModelo).HasMaxLength(4).IsRequired();
            builder.Property(c => c.AnoFabricacao).HasMaxLength(4).IsRequired();
        }
    }
}
