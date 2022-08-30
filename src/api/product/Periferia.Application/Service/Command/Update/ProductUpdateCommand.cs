using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public record ProductUpdateCommand(
        int Id,
        string Name,
        decimal? Price) : IRequest<ProductResult>;
}
