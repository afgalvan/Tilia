using System.Collections.Generic;
using System.Reflection;
using Api.Hubs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Api.Extensions.Swagger
{
    public static class SwaggerDefinition
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                OpenApiSecurityScheme securityScheme = GenerateSecurityScheme();
                options.OperationFilter<AuthorizationOperationFilter>();
                options.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "Tilia", Version = "v1" });
                options.DocumentFilter<SignalRSwaggerGen.SignalRSwaggerGen>(GetHubsAssemblies());
                options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
            });
        }

        private static List<Assembly> GetHubsAssemblies()
        {
            return new List<Assembly> { typeof(AppointmentHub).Assembly };
        }

        private static OpenApiSecurityScheme GenerateSecurityScheme()
        {
            return new OpenApiSecurityScheme
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
        }
    }
}
