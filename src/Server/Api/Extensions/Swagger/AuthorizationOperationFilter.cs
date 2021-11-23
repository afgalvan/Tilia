using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Extensions.Swagger
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        private static IReadOnlyList<AuthorizeAttribute>
            AuthMethods(OperationFilterContext context) => context
            .MethodInfo?.GetCustomAttributes(true)
            .Union(context.MethodInfo.GetCustomAttributes(true))
            .OfType<AuthorizeAttribute>()
            .ToList();

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            IReadOnlyList<AuthorizeAttribute> attributes = AuthMethods(context);
            if (attributes == null || !attributes.Any())
            {
                operation.Security.Clear();
                return;
            }

            AuthorizeAttribute attribute = attributes.ElementAt(0);

            operation.Responses.Add("401", new OpenApiResponse {Description = "Unauthorized"});
            operation.Responses.Add("403", new OpenApiResponse {Description = "Forbidden"});

            IList<string> securitySpecs = new List<string>();
            securitySpecs.Add($"{nameof(AuthorizeAttribute.Policy)}:{attribute.Policy}");
            securitySpecs.Add($"{nameof(AuthorizeAttribute.Roles)}:{attribute.Roles}");
            securitySpecs.Add(
                $"{nameof(AuthorizeAttribute.AuthenticationSchemes)}:{attribute.AuthenticationSchemes}");

            operation.Security = new List<OpenApiSecurityRequirement>
            {
                new()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id   = AuthenticationScheme.Bearer,
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        securitySpecs
                    }
                }
            };
        }
    }
}
