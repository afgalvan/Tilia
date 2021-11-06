using MediatR;

namespace SharedLib.Domain.Bus.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
