using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public record CustomerUpdateCommand(
        int Id,
        string Identification,
        string FirstName,
        string LastName,
        string Phone
        ) : IRequest<CustomerResult>;
}
