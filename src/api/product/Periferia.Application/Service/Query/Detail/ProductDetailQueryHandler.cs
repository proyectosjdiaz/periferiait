using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Query.Detail
{
    public class ProductDetailQueryHandler : IRequestHandler<ProductDetailQuery, ProductResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResult?> Handle(ProductDetailQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.ProductRepository.Detail(request.Id) is not Product product)
                return null;

            return new ProductResult(product.Id, product.Name, product.Price);
        }
    }
}
