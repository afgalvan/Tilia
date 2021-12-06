using Presentation.Components.Administration.Users;
using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;
using Presentation.Components.Administration.Employees;
using Presentation.Components.Administration.Roles;
using Presentation.Services;
using Presentation.Services.Http;

namespace Presentation.Components.Administration
{
    public partial class AdministrationUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly UsersPanelUserControl _usersPanelUser;
        private readonly RolesPanelUserControl _rolesPanel;
        private readonly EmployeesUserControl _employeesPanel;

        public AdministrationUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<UsersService>();
            var rolesService = _mainWindow.GetComponent<RolesService>();
            var employeesService = _mainWindow.GetComponent<EmployeesService>();
            _usersPanelUser = new UsersPanelUserControl(_mainWindow, api, employeesService);
            _rolesPanel = new RolesPanelUserControl(_mainWindow, rolesService);
            _employeesPanel = new EmployeesUserControl(_mainWindow, employeesService);
        }

        private void AdminUsersButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_usersPanelUser);
        }

        private void AdminRolesButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_rolesPanel);
        }

        private void AdminEmployeesButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_employeesPanel);
        }
    }
}
