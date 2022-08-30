using MediatR;
using Periferia.Application.Common.UnitOfWork;
using Periferia.Application.Service.Common;
using Periferia.Domain.Entities;

namespace Periferia.Application.Service.Command.Create
{
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, CustomerResult?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerCreateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CustomerResult?> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.CustomerRepository.ByIdentification(request.Identification) is Customer customer)
                return new CustomerResult(customer.Id, customer.Identification, customer.FirstName, customer.LastName, customer.Phone);

            customer = new Customer
            {
                Id = 0,
                Identification = request.Identification,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Phone = request.Phone
            };

            var success = await _unitOfWork.CustomerRepository.Create(customer);

            if (!success)
            {
                return null;
            }

            await _unitOfWork.SaveChangesAsync();

            return new CustomerResult(customer.Id, customer.Identification, customer.FirstName, customer.LastName, customer.Phone);
        }
    }
}
