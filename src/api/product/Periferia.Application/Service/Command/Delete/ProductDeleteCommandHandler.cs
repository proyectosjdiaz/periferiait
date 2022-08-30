using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, ProductResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResult?> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var success = await _unitOfWork.ProductRepository.Delete(request.Id);

            if (success)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return null;
        }
    }
}
