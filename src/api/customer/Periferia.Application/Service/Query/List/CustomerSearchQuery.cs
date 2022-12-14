using MediatR;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.List
{
    public class CustomerSearchQuery : IRequest<IEnumerable<CustomerResult>>
    {
    }
}
