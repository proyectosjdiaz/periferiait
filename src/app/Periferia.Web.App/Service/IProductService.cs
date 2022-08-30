using Periferia.Web.App.Model.Customer;

namespace Periferia.Web.App.Service
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> List();
        Task<ProductModel?> Detail(int Id);
        Task<ProductModel?> Delete(int Id);
        Task<ProductModel?> Create(ProductModel customer);
        Task<ProductModel?> Update(ProductModel customer);
    }
}
