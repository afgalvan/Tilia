using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;
using Application.Users.Create;
using Application.Users.GenerateJwt;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Application.Extensions
{
    public static class ApplicationDependency
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<SecurityTokenHandler, JwtSecurityTokenHandler>();
            services.AddScoped<JwtGenerator>();
            services.AddScoped<UserCreator>();
            services.AddMediatR(Assembly.Load("Application"));
        }
    }
}
