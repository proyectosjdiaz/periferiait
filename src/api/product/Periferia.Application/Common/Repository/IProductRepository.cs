using Periferia.Domain.Entities;

namespace Periferia.Application.Common.Repository
{
    public interface IProductRepository
    {
        Task<bool> Create(Product product);
        Task<bool> Update(int Id, Product product);
        Task<bool> Delete(int Id);
        Task<IEnumerable<Product>> List();
        Task<Product?> Detail(int Id);
    }
}
