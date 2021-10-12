using MediatR;

namespace Shared.Domain.Bus.Command
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
