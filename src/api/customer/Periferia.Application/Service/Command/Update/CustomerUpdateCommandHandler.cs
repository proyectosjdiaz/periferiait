using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Command.Update
{
    public class CustomerUpdateCommandHandler : IRequestHandler<CustomerUpdateCommand, CustomerResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerUpdateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult?> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = request.Id,
                Identification = request.Identification,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };

            var success = await _unitOfWork.CustomerRepository.Update(request.Id, customer);

            if (!success)
            {
                return null;
            }

            await _unitOfWork.SaveChangesAsync();

            return new CustomerResult(customer.Id, customer.Identification, customer.FirstName, customer.LastName, customer.Phone);
        }
    }
}
