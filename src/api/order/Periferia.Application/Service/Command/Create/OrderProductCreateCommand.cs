namespace Periferia.Application.Service.Command.Create
{
    public record OrderProductCreateCommand(
    int Id,
    int ProductId,
    int Quantity,
    decimal? Price,
    decimal? Total);
}
