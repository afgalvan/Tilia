using System;
using System.Windows.Controls;
using Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Components.Atomic;
using Presentation.Components.Dashboard;
using Presentation.Services.Http;

namespace Presentation.Windows
{
    public partial class MainWindow
    {
        private readonly IServiceProvider _provider;
        private readonly UsersService     _usersService;

        public User LoggedUser { get; set; }

        public MainWindow(IServiceProvider provider, UsersService usersService)
        {
            _provider     = provider;
            _usersService = usersService;
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
            LoggedUser      = null;
            App.AccessToken = null;
            _provider.GetRequiredService<LoginWindow>().Show();
            Hide();
        }

        public T GetComponent<T>()
        {
            return _provider.GetRequiredService<T>();
        }
    }
}
