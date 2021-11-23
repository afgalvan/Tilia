using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Requests.Appointments;
using SignalRSwaggerGen.Attributes;

namespace Api.Hubs
{
    [SignalRHub("/hubs/appointment")]
    public class AppointmentHub : Hub
    {
        [SignalRMethod("register")]
        [return: SignalRReturn(typeof(void), StatusCodes.Status201Created)]
        [return: SignalRReturn(typeof(void), StatusCodes.Status401Unauthorized)]
        [return: SignalRReturn(typeof(void), StatusCodes.Status400BadRequest)]
        public async Task Register([SignalRArg] CreateMedicalAppointmentRequest createRequest)
        {
            await Clients.Caller.SendAsync("");
        }
    }
}
