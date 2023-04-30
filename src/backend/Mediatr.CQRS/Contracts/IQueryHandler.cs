using MediatR;

namespace Mediatr.CQRS.Contracts
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse> { }
}
