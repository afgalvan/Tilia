using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Tilia.Web.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Tilia.Api v1");
                options.DocumentTitle = "Tilia API Documentation";
                options.RoutePrefix   = "api/swagger";
            });
        }

        public static void ConfigureCors(this IApplicationBuilder app,
            IConfiguration configuration)
        {
            var allowedOrigins =
                configuration.GetSection("AllowedOrigins").Get<List<string>>();

            app.UseCors(builder =>
                builder.WithOrigins(allowedOrigins.ToArray())
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
            );
        }
    }
}
