using Microsoft.EntityFrameworkCore;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context.Configuration;

namespace Periferia.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("product");
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
