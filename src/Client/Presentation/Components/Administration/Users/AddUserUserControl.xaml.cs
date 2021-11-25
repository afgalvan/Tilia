using System;
using System.Threading.Tasks;
using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;

namespace Presentation.Components.Administration.Users
{
    public partial class AddUserUserControl : UserControl
    {
        private readonly MainWindow   _mainWindow;
        private readonly UsersService _usersService;

        public AddUserUserControl(MainWindow mainWindow, UsersService usersService)
        {
            _usersService = usersService;
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private async void OnLoaded(object sender, EventArgs e)
        {
            await LoadTableInformation();
        }

        private async void BackToAdminUserControlButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
            MessageBox.Show((await _usersService.GetUserById("6420e496-157e-4bf3-ad3f-4a4f0239d57b",
                App.CancellationToken)).Name);
        }

        private void AddUserButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RemoveUser_OnClick(object sender, RoutedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private async Task LoadTableInformation()
        {
            UsersDataGrid.ItemsSource = await _usersService.GetUsers(App.CancellationToken);
        }
    }
}
