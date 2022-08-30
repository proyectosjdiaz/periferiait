using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;

namespace Periferia.Application.Service.Query.List
{
    public class CustomerSearchQueryHandler : IRequestHandler<CustomerSearchQuery, IEnumerable<CustomerResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerSearchQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CustomerResult>> Handle(CustomerSearchQuery request, CancellationToken cancellationToken)
        {
            var search = await _unitOfWork.CustomerRepository.List();
            var customers = search.Select(s => new CustomerResult(s.Id, s.Identification, s.FirstName, s.LastName, s.Phone));
            return customers;
        }
    }
}
