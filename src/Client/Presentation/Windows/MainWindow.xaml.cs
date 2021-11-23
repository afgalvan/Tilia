using System;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components.Atomic;
using Presentation.Components.Dashboard;

namespace Presentation.Windows
{
    public partial class MainWindow
    {
        private readonly IServiceProvider _provider;

        public MainWindow(IServiceProvider provider)
        {
            _provider = provider;
            InitializeComponent();
            MainContentArea.Content    = new DashboardUserControl();
            HeaderContentArea.Content  = new HeaderUserControl(this);
            SideBarContentArea.Content = new SidebarUserControl(this);
        }

        public void ChangeMainContentArea(UserControl content)
        {
            if (content == null)
            {
                MainContentArea.Content = new DashboardUserControl();
                return;
            }

            if (content.GetType() == MainContentArea.Content.GetType())
            {
                return;
            }

            MainContentArea.Content = content;
        }

        public void LogoutSession()
        {
            _provider.GetRequiredService<LoginWindow>().Show();
            Hide();
        }

        public T GetComponent<T>()
        {
            return _provider.GetRequiredService<T>();
        }
    }
}
