namespace Periferia.Contract;
public record OrderProductRequest(
        int Id,
        int OrderId,
        int ProductId,
        string? ProductName,
        int Quantity,
        decimal? Price,
        decimal? Total);
