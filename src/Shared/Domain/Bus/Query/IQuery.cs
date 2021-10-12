using MediatR;

namespace Shared.Domain.Bus.Query
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}
