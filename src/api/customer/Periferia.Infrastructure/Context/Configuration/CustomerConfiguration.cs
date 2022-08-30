using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Periferia.Domain.Entities;

namespace Periferia.Infrastructure.Context.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("customer");

            entity.Property(e => e.Id)
                .HasColumnType("int")
                .HasColumnName("id");

            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");

            entity.Property(e => e.Identification)
                .HasMaxLength(20)
                .HasColumnName("identification");

            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");

            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
        }
    }
}
