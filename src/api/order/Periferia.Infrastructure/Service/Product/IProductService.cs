namespace Periferia.Infrastructure.Service.Order
{
    public interface IProductService
    {
        Task<ProductData?> Detail(int Id);
    }
}
