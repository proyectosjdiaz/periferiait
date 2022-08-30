using Periferia.Application.Common.Repository;

namespace Periferia.Application.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
