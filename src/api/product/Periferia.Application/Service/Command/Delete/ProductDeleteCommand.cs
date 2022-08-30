using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public record ProductDeleteCommand(
        int Id) : IRequest<ProductResult>;
}
