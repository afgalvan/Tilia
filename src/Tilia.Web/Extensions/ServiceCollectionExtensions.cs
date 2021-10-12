using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Reflection;
using System.Text;
using Application.Users.Create;
using Application.Users.EncryptPassword;
using Application.Users.GenerateJwt;
using Domain.Users;
using Infrastructure.Persistence.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Shared.Infrastructure.Persistence;
using Tilia.Web.Controllers.SignUp;
using Tilia.Web.Extensions.OpenApiSpec;

namespace Tilia.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<SecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<IUserRepository, MySqlUserRepository>();
            services.AddScoped<JwtGenerator>();
            services.AddScoped<AccountCreator>();
            services.AddScoped<Hasher>();
            services.AddScoped<ILogger<SignUpController>, Logger<SignUpController>>();
            services.AddMediatR(Assembly.Load("Tilia.Web"));
        }

        public static void ConfigureDbContext(this IServiceCollection services,
            IConfiguration configuration)
        {
            if (configuration["Database:Provider"].ToLower(CultureInfo.CurrentCulture) ==
                "mysql")
            {
                services.AddDbContext<TiliaDbContext>(options =>
                        options.UseMySql(
                                configuration.GetConnectionString("DefaultConnection"),
                                new MySqlServerVersion(new Version(8, 0, 26)))
                            .UseSnakeCaseNamingConvention(),
                    ServiceLifetime.Transient
                );
            }
        }

        public static void ConfigureProxy(this IServiceCollection services)
        {
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor |
                    ForwardedHeaders.XForwardedProto;
                options.KnownProxies.Add(IPAddress.Parse("0.0.0.0"));
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Name         = "Authorization",
                BearerFormat = "JWT",
                Scheme       = AuthenticationScheme.Bearer,
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                In   = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Reference = new OpenApiReference
                {
                    Id   = AuthenticationScheme.Bearer,
                    Type = ReferenceType.SecurityScheme
                }
            };

            services.AddSwaggerGen(options =>
            {
                options.OperationFilter<AuthorizationOperationFilter>();
                options.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Tilia", Version = "v1" });
                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            });
        }

        public static void AddOAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            byte[] key = Encoding.UTF8.GetBytes(configuration["Security:JwtKey"]);

            services.AddSingleton(_ => new SecretKey(key));

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
                        IssuerSigningKey         = new SymmetricSecurityKey(key),
                        ValidateIssuer           = false,
                        ValidateAudience         = false
                    };
                });
        }
    }
}
