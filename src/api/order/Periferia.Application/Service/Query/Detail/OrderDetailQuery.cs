using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.Detail
{
    public record OrderDetailQuery(
        int Id) : IRequest<OrderResult?>;
}
