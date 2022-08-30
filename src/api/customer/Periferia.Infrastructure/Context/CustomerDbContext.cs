using Microsoft.EntityFrameworkCore;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context.Configuration;

namespace Periferia.Infrastructure.Context
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("customer");
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
