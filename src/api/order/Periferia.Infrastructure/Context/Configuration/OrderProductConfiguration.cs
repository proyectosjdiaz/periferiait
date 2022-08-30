using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Periferia.Domain.Entities;

namespace Periferia.Infrastructure.Context.Configuration
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> entity)
        {
            entity.ToTable("order_product");

            entity.HasIndex(e => e.OrderId, "ix_order_product_order");

            entity.HasIndex(e => e.ProductId, "ix_order_product_product");

            entity.HasIndex(e => new { e.OrderId, e.ProductId }, "uk_order_product")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            entity.Property(e => e.OrderId)
                .HasColumnType("int")
                .HasColumnName("order_id");

            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");

            entity.Property(e => e.ProductId)
                .HasColumnType("int")
                .HasColumnName("product_id");

            entity.Property(e => e.Quantity)
                .HasColumnType("int")
                .HasColumnName("quantity");

            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");

            entity.HasOne(d => d.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order_product_order");
        }
    }
}
