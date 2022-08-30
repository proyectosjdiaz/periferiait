using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Query.Detail
{
    public class CustomerDetailQueryHandler : IRequestHandler<CustomerDetailQuery, CustomerResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerDetailQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult?> Handle(CustomerDetailQuery request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CustomerRepository.Detail(request.Id) is not Customer customer)
                return null;

            return new CustomerResult(customer.Id, customer.Identification, customer.FirstName, customer.LastName, customer.Phone);
        }
    }
}
