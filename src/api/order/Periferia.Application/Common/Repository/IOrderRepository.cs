using Periferia.Domain.Entities;

namespace Periferia.Application.Common.Repository
{
    public interface IOrderRepository
    {
        Task<bool> Create(Order order);
        Task<IEnumerable<Order>> List();
        Task<Order?> Detail(int Id);
    }
}
