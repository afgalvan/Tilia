using System.Windows.Media;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Controllers.Connection;
using Presentation.Settings;
using Presentation.Components.Patients;
using Presentation.Components.Patients.PatientsRegisterForms;
using Presentation.Controllers.Http;
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
            services.AddTransient<RegisterPatientUserControl>();
            services.AddTransient<BasicDataRegisterPage>();
            services.AddTransient<PatientsUserControl>();
            services.AddTransient<ContactDataRegisterPage>();
            services.AddTransient<MedicalDataRegisterPage>();
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
