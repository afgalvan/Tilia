using System.Globalization;
using System.Threading;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Extensions;
using Presentation.Windows;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly       ServiceProvider   _serviceProvider;
        public static          string            AccessToken { get; set; }
        public static readonly CancellationToken CancellationToken = new(false);

        public App()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");
            var services = new ServiceCollection();
            services.AddPresentationServices();
            services.AddServerConnectionServices();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var loginWindow = _serviceProvider.GetRequiredService<LoginWindow>();
            loginWindow?.Show();
        }
    }
}
