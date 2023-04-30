using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr.CQRS.Processors
{
    public class GenericRequestPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public GenericRequestPreProcessor(ILogger<GenericRequestPreProcessor<TRequest>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Incoming REQUEST TYPE: {typeof(TRequest).FullName}; CONTENT: {JsonConvert.SerializeObject(request)}");

            await Task.CompletedTask;
        }
    }
}