using Mediatr.CQRS.Contracts;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using VWB.Api.Commands;

namespace VWB.App.CommandHandlers
{
    public class AddFruitCommandHandler : ICommandHandler<AddFruitCommand>
    {
        private readonly ILogger<AddFruitCommandHandler> _logger;

        public AddFruitCommandHandler(ILogger<AddFruitCommandHandler> logger)
        {
            _logger = logger;
        }

        public async Task<bool> Handle(AddFruitCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Handler started.");
            return await Task.FromResult(true);
        }
    }
}
