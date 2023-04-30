using MediatR;

namespace Mediatr.CQRS.Contracts
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {

    }
}
