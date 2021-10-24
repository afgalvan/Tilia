using System.Windows.Media;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Utils;
using Presentation.Windows;

namespace Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<LoginWindow>();
            services.AddScoped<MainWindow>();
            services.AddSingleton<ColorsUtil>();
            services.AddScoped<BrushConverter>();
        }
    }
}
