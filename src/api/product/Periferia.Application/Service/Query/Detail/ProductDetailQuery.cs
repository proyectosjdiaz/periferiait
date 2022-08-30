using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.Detail
{
    public record ProductDetailQuery(
        int Id) : IRequest<ProductResult?>;
}
