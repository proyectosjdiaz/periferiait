namespace Periferia.Domain.Entities
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Identification { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Phone { get; set; }
    }
}
