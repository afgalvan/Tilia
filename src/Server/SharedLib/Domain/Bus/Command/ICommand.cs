using MediatR;

namespace SharedLib.Domain.Bus.Command
{
    public interface ICommand<out TResponse> : IRequest<TResponse>
    {
    }
}
