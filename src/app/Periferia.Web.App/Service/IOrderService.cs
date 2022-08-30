using Periferia.Web.App.Model.Order;

namespace Periferia.Web.App.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> List();
        Task<OrderModel?> Detail(int Id);
        Task<OrderModel?> Create(OrderModel order);
    }
}
