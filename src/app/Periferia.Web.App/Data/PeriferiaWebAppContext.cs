using Microsoft.EntityFrameworkCore;

namespace Periferia.Web.App.Data
{
    public class PeriferiaWebAppContext : DbContext
    {
        public PeriferiaWebAppContext(DbContextOptions<PeriferiaWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Periferia.Web.App.Model.Customer.ProductModel> CustomerModel { get; set; } = default!;

        public DbSet<Periferia.Web.App.Model.Order.OrderModel>? OrderModel { get; set; }
    }
}
