using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Query.Detail
{
    public class CustomerIdentificationQueryHandler : IRequestHandler<CustomerIdentificationQuery, CustomerResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerIdentificationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult?> Handle(CustomerIdentificationQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CustomerRepository.ByIdentification(request.Identification) is not Customer customer)
                return null;

            return new CustomerResult(customer.Id, customer.Identification, customer.FirstName, customer.LastName, customer.Phone);
        }
    }
}
