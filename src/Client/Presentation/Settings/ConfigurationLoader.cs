using Microsoft.Extensions.Configuration;

namespace Presentation.Settings
{
    public class ConfigurationLoader
    {
        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();
    }
}
