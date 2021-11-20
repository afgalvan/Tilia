using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components.Patients;
using Presentation.Components.Patients.PatientsRegisterForms;
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
            services.AddTransient<PatientsRegisterUserControl>();
            services.AddTransient<BasicDataRegisterPage>();
            services.AddTransient<ContactDataRegisterPage>();
            services.AddTransient<MedicalDataRegisterPage>();
            services.AddSingleton<ColorsUtil>();
            services.AddScoped<BrushConverter>();
        }
    }
}
