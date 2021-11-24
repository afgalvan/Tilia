using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.Connection;
using Presentation.Services.Http;
using Presentation.Services.Http.Utils;
using Presentation.Settings;
using Presentation.Utils;
using Presentation.Windows;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddTransient<LoginWindow>();
            services.AddTransient<MainWindow>();
            services.AddSingleton<ColorsUtil>();
            services.AddScoped<BrushConverter>();
        }

        public static void AddServerConnectionServices(this IServiceCollection services)
        {
            IConfiguration   configuration    = ConfigurationLoader.Configuration;
            ConnectionConfig connectionConfig = ConfigurationLoader.Tunnel(configuration);
            var              restClient       = new RestClient(connectionConfig.Host)
            {
                ThrowOnAnyError = true
            };
            restClient.UseNewtonsoftJson();
            services.AddSingleton(restClient);
            services.AddSingleton(connectionConfig);
            services.AddSingleton(configuration);
            services.AddSingleton<HubConnectionBuilder>();
            services.AddScoped<RestComposer>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<SocketConnection>();
            services.AddScoped<ContextDataRetriever>();
        }
    }
}
