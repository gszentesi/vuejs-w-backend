using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Mediatr.CQRS.Behaviours
{
    public class GenericPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<Behaviours.GenericPipelineBehavior<TRequest, TResponse>> _logger;
        private readonly IRequestHandler<TRequest, TResponse> _inner;
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IEnumerable<IRequestPreProcessor<TRequest>> _preProcessors;
        private readonly IEnumerable<IRequestPostProcessor<TRequest, TResponse>> _postProcessors;

        public GenericPipelineBehavior(
            ILogger<GenericPipelineBehavior<TRequest, TResponse>> logger,
            IRequestHandler<TRequest, TResponse> inner,
            IEnumerable<IValidator<TRequest>> validators,
            IEnumerable<IRequestPreProcessor<TRequest>> preProcessors,
            IEnumerable<IRequestPostProcessor<TRequest, TResponse>> postProcessors
            )
        {
            _logger = logger;
            _inner = inner;
            _validators = validators;
            _preProcessors = preProcessors;
            _postProcessors = postProcessors;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogDebug("Executing preprocessors.");
            foreach (var preProcessor in _preProcessors)
                await preProcessor.Process(request, cancellationToken);

            _logger.LogDebug("Executing validators.");
            var failures = _validators.ToList()
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            _logger.LogDebug("Handling reuqest.");
            var response = await _inner.Handle(request, cancellationToken);

            _logger.LogDebug("Executing postprocessors.");
            foreach (var postProcessor in _postProcessors)
                await postProcessor.Process(request, response, cancellationToken);

            return response;
        }
    }
}
