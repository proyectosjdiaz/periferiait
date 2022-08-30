using MediatR;
using Microsoft.AspNetCore.Mvc;
using Periferia.Application.Service.Command.Create;
using Periferia.Application.Service.Command.Update;
using Periferia.Application.Service.Query.Detail;
using Periferia.Application.Service.Query.List;
using Periferia.Contract;

namespace Periferia.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("detail/{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            ProductDetailQuery query = new(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("list/")]
        public async Task<IActionResult> List()
        {
            ProductSearchQuery query = new();
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductRequest request)
        {
            var command = new ProductCreateCommand(
                request.Id,
                request.Name,
                request.Price);

            var customer = await _mediator.Send(command);

            return Ok(new { Id = customer?.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductRequest request)
        {
            var command = new ProductUpdateCommand(
                request.Id,
                request.Name,
                request.Price);

            var customer = await _mediator.Send(command);

            return Ok(new { Id = customer?.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDeleteCommand query = new(id);
            return Ok(await _mediator.Send(query));
        }
    }
}
