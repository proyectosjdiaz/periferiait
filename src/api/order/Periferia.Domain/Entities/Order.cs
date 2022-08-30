namespace Periferia.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal? Total { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
