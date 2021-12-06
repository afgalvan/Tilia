using System.Windows.Media;
using LiveChartsCore;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components.Atomic;
using Presentation.Services;
using Presentation.Services.Http;
using Presentation.Services.Http.Connection;
using Presentation.Services.Hubs.Connection;
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
            var restClient = new RestClient(connectionConfig.Host)
            {
                ThrowOnAnyError = true
            };
            restClient.UseNewtonsoftJson();
            services.AddSingleton<IRestClient>(restClient);
            services.AddSingleton(connectionConfig);
            services.AddSingleton(configuration);
            services.AddSingleton<HubConnectionBuilder>();
            services.AddScoped<IRestComposer, RestComposer>();
            services.AddScoped<RestFetcher>();
            services.AddScoped<AuthenticationService>();
            services.AddScoped<SocketConnection>();
            services.AddScoped<UsersService>();
            services.AddScoped<RolesService>();
            services.AddScoped<AppointmentsService>();
            services.AddScoped<EmployeesService>();
            services.AddScoped<DashboardService>();
            services.AddScoped<PatientService>();
            services.AddScoped<ContextDataRetriever>();
        }
    }
}
