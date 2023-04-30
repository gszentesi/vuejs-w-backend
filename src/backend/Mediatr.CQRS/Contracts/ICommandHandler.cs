using MediatR;

namespace Mediatr.CQRS.Contracts
{
    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, bool> where TRequest : ICommand { }
}

