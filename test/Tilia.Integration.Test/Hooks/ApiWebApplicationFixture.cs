using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Infrastructure.Persistence;
using Tilia.Integration.Test.Mocks;
using Tilia.Web;

namespace Tilia.Integration.Test.Hooks
{
    public class ApiWebApplicationFixture : WebApplicationFactory<Startup>
    {
        private IConfiguration Configuration { get; set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.Test.json")
                    .Build();
                config.AddConfiguration(Configuration);
            });
            builder.ConfigureTestServices(services =>
            {
                services.AddScoped<TiliaDbContext, TestDbContext>();
            });
        }
    }
}
