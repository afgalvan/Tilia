﻿using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Application.Users.Authenticate;
using Application.Users.Create;
using Domain.Locations.Repositories;
using Domain.People.Repositories;
using Domain.Users;
using Domain.Users.Repositories;
using Hangfire;
using Hangfire.Storage.SQLite;
using Infrastructure.Persistence.IdTypes;
using Infrastructure.Persistence.Locations;
using Infrastructure.Persistence.Users;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Requests.Auth;
using Requests.Users;
using Server.Controllers;
using Server.Extensions.Settings;
using Server.Hubs;
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

        public static void AddJwtAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            string secretKey = configuration["SecretKey:Key"];
            services.AddSingleton(_ => new SecretKey(secretKey));
            byte[] encodedKey = Encoding.UTF8.GetBytes(secretKey);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme    = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime         = true,
                        IssuerSigningKey         = new SymmetricSecurityKey(encodedKey),
                        ValidateIssuer           = false,
                        ValidateAudience         = false
                    };
                });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Tilia", Version = "v1" });
                options.DocumentFilter<SignalRSwaggerGen.SignalRSwaggerGen>(new List<Assembly>
                    { typeof(AuthenticationController).Assembly, typeof(AppointmentHub).Assembly });
            });
        }
    }
}
