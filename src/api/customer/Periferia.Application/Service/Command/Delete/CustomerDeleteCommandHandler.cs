using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Command.Update
{
    public class CustomerDeleteCommandHandler : IRequestHandler<CustomerDeleteCommand, CustomerResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDeleteCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult?> Handle(CustomerDeleteCommand request, CancellationToken cancellationToken)
        {
            var success = await _unitOfWork.CustomerRepository.Delete(request.Id);

            if (success)
            {
                await _unitOfWork.SaveChangesAsync();
            }

            return null;
        }
    }
}
