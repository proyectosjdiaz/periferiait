namespace Periferia.Web.App.Model.Order
{
    public record OrderModel(
    int Id,
    int CustomerId,
    string? Identification,
    string? FirstName,
    string? LastName,
    string? Phone,
    decimal? Total,
    IEnumerable<OrderProductModel>? OrderProducts);
}
