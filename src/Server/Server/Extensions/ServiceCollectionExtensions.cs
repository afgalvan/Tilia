using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using Domain.Users;
using Infrastructure.Persistence.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Server.Hubs;
using Shared.Infrastructure.Persistence;

namespace Server.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            string provider = configuration["Database:Provider"];
            if (provider.ToLower(CultureInfo.CurrentCulture) == "mysql")
            {
                services.AddDbContext<TiliaDbContext>(options =>
                    options.UseMySql(
                            configuration.GetConnectionString("DefaultConnection"),
                            new MySqlServerVersion(new Version(8, 0, 26)))
                        .UseSnakeCaseNamingConvention()
                );
            }
        }

        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, MySqlUserRepository>();
        }

        public static void AddOAuth(this IServiceCollection services,
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
                    { typeof(UserHub).Assembly });
            });
        }
    }
}
