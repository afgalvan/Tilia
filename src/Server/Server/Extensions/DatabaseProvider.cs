using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Server.Extensions
{
    public class ConnectionInformation
    {
        public string Url      { get; set; }
        public string Provider { get; set; }

        public ConnectionInformation(IConfiguration configuration, string provider)
        {
            Url      = configuration.GetConnectionString($"{provider}Connection");
            Provider = provider;
        }
    }

    public static class DatabaseProvider
    {
        private const string MigrationsAssembly = "Server";

        public static DbContextOptionsBuilder SetupDatabaseEngine(
            this DbContextOptionsBuilder options,
            ConnectionInformation connectionInformation) =>
            connectionInformation.Provider switch
            {
                "Oracle" => SetupOracle(options, connectionInformation.Url),
                _ => SetupMysql(options, connectionInformation.Url)
            };

        private static DbContextOptionsBuilder SetupMysql(DbContextOptionsBuilder options,
            string connectionString)
        {
            return options.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 26)),
                builder => builder.MigrationsAssembly(MigrationsAssembly));
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
