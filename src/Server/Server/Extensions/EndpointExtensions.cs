using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR;
using Server.Controllers;
using Server.Hubs;
using SignalRSwaggerGen;
using SignalRSwaggerGen.Attributes;

namespace Server.Extensions
{
    public static class EndpointExtensions
    {
        public static void ConfigureHubMaps(this IEndpointRouteBuilder endpoints)
        {
            endpoints.UseHubNamePlaceHolder<AppointmentHub>();
        }

        private static void UseHubNamePlaceHolder<THub>(this IEndpointRouteBuilder endpoints) where THub : Hub
        {
            endpoints.MapHub<THub>(typeof(THub).GetCustomAttribute<SignalRHubAttribute>()
                ?.Path.Replace(Constants.HubNamePlaceholder, nameof(THub)));
        }
    }
}
