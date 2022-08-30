using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Periferia.Domain.Entities;

namespace Periferia.Infrastructure.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");

            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
        }
    }
}
