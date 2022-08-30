using Microsoft.EntityFrameworkCore;
using Periferia.Infrastructure.Context;

namespace Periferia.Migrations.Context
{
    public class MigrationDbContext : OrderDbContext
    {
        public MigrationDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
    }
}
