using System.Globalization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Server.Extensions
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

    public static class DatabaseProvider
    {
        private const string MigrationsAssembly = "Server";

        public static DbContextOptionsBuilder SetupDatabaseEngine(
            this DbContextOptionsBuilder options,
            DbConnectionConfig dbConnectionConfig) =>
            dbConnectionConfig.Provider.ToLower(CultureInfo.CurrentCulture) switch
            {
                "oracle" => SetupOracle(options, dbConnectionConfig.Url),
                _ => SetupMysql(options, dbConnectionConfig.Url)
            };

        private static DbContextOptionsBuilder SetupMysql(DbContextOptionsBuilder options,
            string connectionString)
        {
            return null;
        }

        private static DbContextOptionsBuilder SetupOracle(DbContextOptionsBuilder options,
            string connectionString)
        {
            return options.UseOracle(connectionString,
                    builder => builder.MigrationsAssembly(MigrationsAssembly))
                .EnableDetailedErrors();
        }
    }
}
