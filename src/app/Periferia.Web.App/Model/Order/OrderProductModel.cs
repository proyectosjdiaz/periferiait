namespace Periferia.Web.App.Model.Order
{
    public record OrderProductModel(
        int Id,
        int OrderId,
        int ProductId,
        string? ProductName,
        int Quantity,
        decimal? Price,
        decimal? Total);
}
