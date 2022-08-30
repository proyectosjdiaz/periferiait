using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.List
{
    public class ProductSearchQueryHandler : IRequestHandler<ProductSearchQuery, IEnumerable<ProductResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductSearchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductResult>> Handle(ProductSearchQuery request, CancellationToken cancellationToken)
        {
            var search = await _unitOfWork.ProductRepository.List();
            var products = search.Select(s => new ProductResult(s.Id, s.Name, s.Price));
            return products;
        }
    }
}
