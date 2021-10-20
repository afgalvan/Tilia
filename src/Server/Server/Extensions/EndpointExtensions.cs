using System.Reflection;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;
using Server.Hubs;
using SignalRSwaggerGen;
using SignalRSwaggerGen.Attributes;

namespace Server.Extensions
{
    public static class EndpointExtensions
    {
        public static void ConfigureHubMaps(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<UserHub>(typeof(UserHub).GetCustomAttribute<SignalRHubAttribute>()
                ?.Path.Replace(Constants.HubNamePlaceholder, nameof(UserHub)));
        }
    }
}
