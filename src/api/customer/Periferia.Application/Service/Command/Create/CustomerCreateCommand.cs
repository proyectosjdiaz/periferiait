using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Create
{
    public record CustomerCreateCommand(
        int Id,
        string Identification,
        string FirstName,
        string LastName,
        string Phone
        ) : IRequest<CustomerResult>;
}
