using Microsoft.EntityFrameworkCore;
using Periferia.Application.Common.Repository;
using Periferia.Domain.Entities;
using Periferia.Infrastructure.Context;

namespace Periferia.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<bool> Create(Product product)
        {
            await _productDbContext.AddAsync(product);
            return true;
        }

        public async Task<bool> Update(int Id, Product product)
        {
            if (await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id) is Product origin)
            {
                origin.Name = product.Name;
                origin.Price = product.Price;
            }
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            if (await _productDbContext.Products.FirstOrDefaultAsync(x => x.Id == Id) is Product product)
            {
                _productDbContext.Products.Remove(product);
            }
            return true;
        }

        public async Task<IEnumerable<Product>> List()
        {
            return _productDbContext.Products;
        }

        public async Task<Product?> Detail(int Id)
        {
            return await _productDbContext.Products.FirstOrDefaultAsync(c => c.Id.Equals(Id));
        }
    }
}
