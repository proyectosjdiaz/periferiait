using Periferia.Domain.Entities;

namespace Periferia.Application.Common.Repository
{
    public interface IOrderProductRepository
    {
        Task<bool> Create(OrderProduct orderProduct);
        Task<IEnumerable<OrderProduct>> OrderProductByOrderId(int orderId);
    }
}
