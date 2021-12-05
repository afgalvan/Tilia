using Presentation.Components.Administration.Users;
using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Administration.Roles;
using Presentation.Services.Http;

namespace Presentation.Components.Administration
{
    public partial class AdministrationUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly UsersPanelUserControl _usersPanelUser;
        private readonly RolesPanelUserControl _rolesPanel;

        public AdministrationUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<UsersService>();
            var rolesService = _mainWindow.GetComponent<RolesService>();
            _usersPanelUser = new UsersPanelUserControl(_mainWindow, api);
            _rolesPanel = new RolesPanelUserControl(_mainWindow, rolesService);
        }

        private void AdminUsersButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_usersPanelUser);
        }

        private void AdminRolesButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_rolesPanel);
        }
    }
}
