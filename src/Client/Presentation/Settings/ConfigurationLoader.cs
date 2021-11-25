using System;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Presentation.Services.Http.Connection;
using RestSharp;

namespace Presentation.Settings
{
    public static class ConfigurationLoader
    {
        public static IConfiguration Configuration =>
            new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false, true)
                .Build();

        private static bool HasRemoteConnection(this IConfiguration configuration)
        {
            return configuration["Server:Scope"]
                .Equals("remote", StringComparison.OrdinalIgnoreCase);
        }

        private static ConnectionConfig FetchConnectionConfig(string url)
        {
            var client = new RestClient(url)
            {
                ThrowOnAnyError = true
            };
            var request = new RestRequest(Method.GET);
            return JsonConvert.DeserializeObject<ConnectionConfig>(client.Get(request)
                .Content);
        }

        public static ConnectionConfig Tunnel(IConfiguration configuration)
        {
            return configuration.HasRemoteConnection()
                ? FetchConnectionConfig(configuration["Server:Tunnel:ConfigUrl"])
                : new ConnectionConfig(configuration["Server:LocalUrl"]);
        }
    }
}
