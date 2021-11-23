using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Application.Users.Authenticate;
using Application.Users.Create;
using Application.Users.FindById;
using Application.Users.GenerateJwt;
using Application.Users.GetAll;
using Domain.Locations.Repositories;
using Domain.People.Repositories;
using Domain.Users.Repositories;
using Hangfire;
using Hangfire.Storage.SQLite;
using Infrastructure.Persistence.IdTypes;
using Infrastructure.Persistence.Locations;
using Infrastructure.Persistence.Users;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Requests.Auth;
using Requests.Users;
using Server.Controllers;
using Server.Extensions.Settings;
using SharedLib.Persistence;

namespace Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionInformation = new DbConnectionConfig(configuration);

            services.AddDbContext<TiliaDbContext>(options =>
                options.SetupDatabaseEngine(connectionInformation)
                    .UseSnakeCaseNamingConvention()
            );
        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<SecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<JwtGenerator>();
            services.AddScoped<UserCreator>();
            services.AddScoped<UsersRetriever>();
            services.AddScoped<UserFinder>();
            services.AddScoped<UserAuthenticator>();
            services.AddMediatR(Assembly.Load("Application"));
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.ConfigureHangFire();
            services.AddSingleton(GetTypeAdapterConfig());
            services.AddScoped<IMapper, ServiceMapper>();
            services.AddScoped<IUsersRepository, OracleUsersRepository>();
            services.AddScoped<IIdTypesRepository, OracleIdTypesRepository>();
            services.AddScoped<ILocationsRepository, OracleLocationsRepository>();
            services.AddScoped<ILogger<AuthenticationController>, Logger<AuthenticationController>>();
        }

        private static void ConfigureHangFire(this IServiceCollection services)
        {
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSQLiteStorage()
            );
            services.AddHangfireServer();
        }

        private static TypeAdapterConfig GetTypeAdapterConfig()
        {
            var configuration = new TypeAdapterConfig();
            configuration.NewConfig<CreateUserRequest, CreateUserCommand>();
            configuration.NewConfig<LoginUserRequest, AuthenticateCommand>();
            return configuration;
        }
    }
}
