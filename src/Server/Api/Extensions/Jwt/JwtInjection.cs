using System.Text;
using Domain.Users;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extensions.Jwt
{
    public static class JwtInjection
    {
        public static void AddJwtAuth(this IServiceCollection services,
            IConfiguration configuration)
        {
            string secretKey = configuration["SecretKey:Key"];
            services.AddSingleton(new SecretKey(secretKey));
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
    }
}
