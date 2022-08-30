namespace Periferia.Web.App.Model.Customer
{
    public record CustomerModel(
        int Id,
        string Identification,
        string FirstName,
        string LastName,
        string Phone);
}
