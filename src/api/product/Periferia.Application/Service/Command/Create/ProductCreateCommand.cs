using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Create
{
    public record ProductCreateCommand(
        int Id,
        string Name,
        decimal? Price) : IRequest<ProductResult>;
}
