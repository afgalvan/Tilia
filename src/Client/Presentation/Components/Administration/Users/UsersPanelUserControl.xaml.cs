using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;

namespace Presentation.Components.Administration.Users
{
    public partial class UsersPanelUserControl : UserControl
    {
        private readonly MainWindow   _mainWindow;
        private readonly UsersService _usersService;

        public UsersPanelUserControl(MainWindow mainWindow, UsersService usersService)
        {
            _usersService = usersService;
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private async void BackToAdminUserControlButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
        }

        private void AddUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
