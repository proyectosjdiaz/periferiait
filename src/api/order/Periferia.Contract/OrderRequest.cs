namespace Periferia.Contract;

public record OrderRequest(
    int Id,
    int CustomerId,
    string? Identification,
    string? FirstName,
    string? LastName,
    string? Phone,
    decimal? Total,
    IEnumerable<OrderProductRequest>? OrderProducts);
