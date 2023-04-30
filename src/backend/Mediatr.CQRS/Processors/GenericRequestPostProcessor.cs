using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr.CQRS.Processors
{

    public class GenericRequestPostProcessor<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly ILogger _logger;

        public GenericRequestPostProcessor(ILogger<GenericRequestPostProcessor<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            _logger.LogDebug($"Completed REQUEST TYPE: {typeof(TRequest).FullName}; CONTENT: {JsonConvert.SerializeObject(request)};" +
                $" RESPONSE TYPE: {typeof(TResponse).FullName}; CONTENT: {JsonConvert.SerializeObject(response)}");

            await Task.CompletedTask;
        }
    }
}