using Microsoft.EntityFrameworkCore;
using Periferia.Infrastructure.Context;

namespace Periferia.Migrations.Context
{
    public class MigrationDbContext : CustomerDbContext
    {
        public MigrationDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
        }
    }
}
