using System.Threading;
using System.Threading.Tasks;

namespace Domain.SharedLib.Email
{
    public interface IEmailSender<in TEntity>
    {
        Task SendMail(TEntity entity, CancellationToken cancellation);
    }
}
