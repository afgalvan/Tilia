using Microsoft.Extensions.Configuration;
using RestWrapper;

namespace Presentation.Settings
{
    public static class ConfigurationLoader
    {
        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

        public static ConnectionConfig Tunnel(IConfiguration configuration) =>
            new RestRequest(configuration["Tunnel:ConfigUrl"])
                .Send()
                .DataFromJson<ConnectionConfig>();
    }
}
