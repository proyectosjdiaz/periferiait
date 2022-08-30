namespace Periferia.Application.Service.Common
{
    public class OrderResult
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Identification { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public decimal? Total { get; set; }
        public List<OrderProductResult>? OrderProducts { get; set; }
    }
}
