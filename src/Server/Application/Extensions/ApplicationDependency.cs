using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using Application.Users.Create;
using Application.Users.GenerateJwt;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Extensions
{
    public static class ApplicationDependency
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<SecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<JwtGenerator>();
            services.AddScoped<UserCreator>();
            services.AddMediatR(Assembly.Load("Application"));
        }
    }
}
