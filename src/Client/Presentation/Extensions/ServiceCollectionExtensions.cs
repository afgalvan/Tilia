using Microsoft.Extensions.DependencyInjection;
using Presentation.Components;

namespace Presentation.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<MainPanel>();
        }
    }
}
