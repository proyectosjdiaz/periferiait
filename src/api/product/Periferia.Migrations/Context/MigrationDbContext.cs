using Microsoft.EntityFrameworkCore;
using Periferia.Infrastructure.Context;

namespace Periferia.Migrations.Context
{
    public class MigrationDbContext : ProductDbContext
    {
        public MigrationDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
    }
}
