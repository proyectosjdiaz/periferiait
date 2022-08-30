using Periferia.Application.Common.Repository;

namespace Periferia.Application.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
