using Microsoft.Extensions.Configuration;

namespace Server.Extensions.Settings
{
    public class DbConnectionConfig
    {
        public string Url      { get; set; }
        public string Provider { get; set; }

        public DbConnectionConfig(IConfiguration configuration)
        {
            Provider = configuration["Database:Provider"];
            Url      = configuration.GetConnectionString($"{Provider}Connection");
        }
    }
}
