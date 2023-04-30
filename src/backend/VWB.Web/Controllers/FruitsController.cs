using MediatR;
using Microsoft.AspNetCore.Mvc;
using VWB.Api.Commands;
using VWB.Api.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RWA.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FruitsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("name")]
        public async Task<GetFruitQuery.Response> GetFruit(string name, CancellationToken ct)
        {
            return await _mediator.Send(new GetFruitQuery(name), ct);
        }

        [HttpPost]
        public async Task Add([FromBody] AddFruitCommand toAdd, CancellationToken ct)
        {
            await _mediator.Send(toAdd, ct);
        }
    }
}
