using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Command.Create
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, ProductResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResult?> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Price = request.Price
            };

            var success = await _unitOfWork.ProductRepository.Create(product);

            if (!success)
            {
                return null;
            }

            await _unitOfWork.SaveChangesAsync();

            return new ProductResult(product.Id, product.Name, product.Price);
        }
    }
}
