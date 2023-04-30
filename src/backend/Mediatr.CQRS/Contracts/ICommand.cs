using MediatR;

namespace Mediatr.CQRS.Contracts
{
    public interface ICommand : IRequest<bool>
    {

    }
}
