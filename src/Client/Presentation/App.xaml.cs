using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components;
using Presentation.Extensions;

namespace Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            services.AddPresentationServices();
            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainPanel = _serviceProvider.GetService<MainPanel>();
            mainPanel?.Show();
        }
    }
}
