using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Presentation.Services;
using Presentation.Services.Http;

namespace Presentation.Components.Administration.Users
{
    public partial class UsersPanelUserControl : UserControl
    {
        private readonly MainWindow   _mainWindow;
        private readonly UsersService _usersService;
        private readonly EmployeesService _employeesService;

        public UsersPanelUserControl(MainWindow mainWindow, UsersService usersService, EmployeesService employeesService)
        {
            _usersService = usersService;
            _employeesService = employeesService;
            InitializeComponent();
            _mainWindow          =  mainWindow;
            UsersDataGrid.Loaded += LoadTableInformation;
        }

        private void BackToAdminUserControlButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
        }

        private void AddUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(
                new AddNewUserFormUserControl(_mainWindow, _usersService, _employeesService));
        }

        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private async void LoadTableInformation(object sender, RoutedEventArgs e)
        {
            UsersDataGrid.ItemsSource =
                await _usersService.GetUsers(App.CancellationToken, App.AccessToken);
        }
    }
}
