namespace Periferia.Contract;
public record CustomerRequest(
    int Id,
    string Identification,
    string Firstname,
    string LastName,
    string Phone);