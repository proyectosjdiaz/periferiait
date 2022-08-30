namespace Periferia.Application.Service.Common
{
    public record CustomerResult(
        int Id,
        string Identification,
        string FirstName,
        string LastName,
        string Phone);
}
