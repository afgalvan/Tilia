using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Services.Connection;
using Presentation.Services.Http;
using Presentation.Settings;
using Presentation.Utils;
using Presentation.Windows;

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
            IConfiguration configuration = ConfigurationLoader.Configuration;
            services.AddSingleton(ConfigurationLoader.Tunnel(configuration));
            services.AddSingleton(configuration);
            services.AddSingleton<HubConnectionBuilder>();
            services.AddScoped<ServerConnection>();
            services.AddScoped<ContextDataRetriever>();
        }
    }
}
