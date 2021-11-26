using System;
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
                .To(user.Email)
                .HighPriority()
                .Subject("Bienvenido a Tilia.")
                .Body(
                    $"Sr/a {user.Employee?.FirstName} acaba de ser registrado como uno de nuestros empleados el dia {DateTime.Now.ToShortDateString()}")
                .SendAsync(cancellation);
        }
    }
}
