using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Periferia.Domain.Entities;

namespace Periferia.Infrastructure.Context.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("order");

            entity.HasIndex(e => e.CustomerId, "ix_order_customer");

            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            entity.Property(e => e.CustomerId)
                .HasColumnType("int")
                .HasColumnName("customer_id");

            entity.Property(e => e.Total)
                .HasPrecision(10, 2)
                .HasColumnName("total");
        }
    }
}
