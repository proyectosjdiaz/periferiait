using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Create
{
    public record OrderCreateCommand(
    int Id,
    int CustomerId,
    decimal? Total,
    IEnumerable<OrderProductCreateCommand> OrderProducts) : IRequest<OrderResult>;
}
