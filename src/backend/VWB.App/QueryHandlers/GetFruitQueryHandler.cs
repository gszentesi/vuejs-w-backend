using Mediatr.CQRS.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using VWB.Api.Queries;

namespace VWB.App.QueryHandlers
{
    public class GetFruitQueryHandler : IQueryHandler<GetFruitQuery, GetFruitQuery.Response>
    {
        private readonly ILogger<GetFruitQueryHandler> _logger;

        public GetFruitQueryHandler(ILogger<GetFruitQueryHandler> logger)
        {
            _logger = logger;
        }

        public async Task<GetFruitQuery.Response> Handle(GetFruitQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handler started.");
            return await Task.FromResult(new GetFruitQuery.Response(request.Name, "piros"));
        }
    }
}