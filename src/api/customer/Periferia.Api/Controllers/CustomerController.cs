using MediatR;
using Microsoft.AspNetCore.Mvc;
using Periferia.Application.Service.Command.Create;
using Periferia.Application.Service.Command.Update;
using Periferia.Application.Service.Query.Detail;
using Periferia.Application.Service.Query.List;
using Periferia.Contract;

namespace Periferia.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("identification/{identification}")]
        public async Task<IActionResult> ByIdentification(string identification)
        {
            CustomerIdentificationQuery query = new(identification);
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            CustomerDetailQuery query = new(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("list/")]
        public async Task<IActionResult> List()
        {
            CustomerSearchQuery query = new();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerRequest request)
        {
            var command = new CustomerCreateCommand(
                request.Id,
                request.Identification,
                request.Firstname,
                request.LastName,
                request.Phone);

            var customer = await _mediator.Send(command);

            return Ok(new { Id = customer?.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CustomerRequest request)
        {
            var command = new CustomerUpdateCommand(
                request.Id,
                request.Identification,
                request.Firstname,
                request.LastName,
                request.Phone);

            var customer = await _mediator.Send(command);

            return Ok(new { Id = customer?.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            CustomerDeleteCommand query = new(id);
            return Ok(await _mediator.Send(query));
        }
    }
}
