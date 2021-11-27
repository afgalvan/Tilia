using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.SharedLib.Email;
using Domain.Users;
using FluentEmail.Core;

namespace Infrastructure.Email
{
    public class UserEmailSender : IEmailSender<User>
    {
        private readonly IFluentEmail _fluentEmail;

        public UserEmailSender(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task SendMail(User entity, CancellationToken cancellation)
        {
            await _fluentEmail
                .To(entity.Email)
                .HighPriority()
                .Subject("Bienvenido a Tilia.")
                .Body(
                    $"Sr/a {entity.Employee?.FirstName} acaba de ser registrado como uno de nuestros empleados el dia {DateTime.Now.ToShortDateString()}")
                .SendAsync(cancellation);
        }
    }
}
