namespace Periferia.Infrastructure.Service.Customer
{
    public record CustomerData(
        int Id,
        string? Identification,
        string? FirstName,
        string? LastName,
        string? Phone);
}
