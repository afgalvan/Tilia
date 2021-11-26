using System.Threading;
using System.Threading.Tasks;
using Domain.Users;
using FluentEmail.Core;

namespace Application.Users.SendMail
{
    public class EmailSender
    {
        private readonly IFluentEmail _fluentEmail;

        public EmailSender(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendMail(User user, CancellationToken cancellation)
        {
            await _fluentEmail
                .SetFrom("andresgalfajar@gmail.com", "Tilia")
                .To(user.Email)
                .HighPriority()
                .Subject("Verificar cuenta de Tilia.")
                .Body()
                .SendAsync(cancellation);
        }
    }
}
