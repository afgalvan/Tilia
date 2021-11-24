using Microsoft.Extensions.Configuration;
using Presentation.Services.Http.Utils;

namespace Presentation.Settings
{
    public static class ConfigurationLoader
    {
        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

        public static ConnectionConfig Tunnel(IConfiguration configuration) =>
            RestComposer.FetchConnectionConfig(configuration["Tunnel:ConfigUrl"]);
    }
}
