using MediatR;
using Microsoft.AspNetCore.Mvc;
using Periferia.Application.Service.Command.Create;
using Periferia.Application.Service.Query.Detail;
using Periferia.Application.Service.Query.List;
using Periferia.Contract;
using Periferia.Infrastructure.Service.Customer;
using Periferia.Infrastructure.Service.Order;

namespace Periferia.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;

        public OrderController(IMediator mediator, ICustomerService customerService, IProductService productService)
        {
            _mediator = mediator;
            _customerService = customerService;
            _productService = productService;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            OrderDetailQuery query = new(id);

            var order = await _mediator.Send(query);

            if (await _customerService.Detail(order.CustomerId.Value) is CustomerData customer)
            {
                order.Identification = customer.Identification;
                order.FirstName = customer.FirstName;
                order.LastName = customer.LastName;
                order.Phone = customer.Phone;

                foreach (var product in order.OrderProducts)
                {
                    if (await _productService.Detail(product.ProductId) is ProductData productData)
                    {
                        product.ProductName = productData.Name;
                    }
                }
            }

            return Ok(order);
        }

        [HttpGet("list/")]
        public async Task<IActionResult> List()
        {
            OrderSearchQuery query = new();

            var orders = (await _mediator.Send(query)).ToList();

            foreach (var order in orders)
            {
                if (await _customerService.Detail(order.CustomerId.Value) is CustomerData customer)
                {
                    order.Identification = customer.Identification;
                    order.FirstName = customer.FirstName;
                    order.LastName = customer.LastName;
                    order.Phone = customer.Phone;
                }
            }

            return Ok(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderRequest request)
        {
            var customerData = new CustomerData
            (
                Id: 0,
                Identification: request.Identification,
                FirstName: request.FirstName,
                LastName: request.LastName,
                Phone: request.Phone
            );

            if (await _customerService.CreateCustomer(customerData) is not CustomerData customer)
                return NotFound();

            var command = new OrderCreateCommand(
                request.Id,
                customer.Id,
                request.Total,
                request.OrderProducts.Select(s => new OrderProductCreateCommand(Id: s.Id,
                                                                                ProductId: s.ProductId,
                                                                                Quantity: s.Quantity,
                                                                                Price: s.Price,
                                                                                Total: s.Total)));

            var order = await _mediator.Send(command);

            return Ok(new { Id = order?.Id });
        }
    }
}
