namespace Periferia.Contract
{
    public record ProductRequest(
        int Id,
        string Name,
        decimal? Price);
}
