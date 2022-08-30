using Periferia.Application.Common.Repository;

namespace Periferia.Application.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
