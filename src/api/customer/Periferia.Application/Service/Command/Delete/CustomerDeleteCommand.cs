using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public record CustomerDeleteCommand(
        int Id) : IRequest<CustomerResult>;
}
