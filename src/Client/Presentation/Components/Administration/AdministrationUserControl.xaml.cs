using Presentation.Components.Administration.Users;
using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;

namespace Presentation.Components.Administration
{
    public partial class AdministrationUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly AddUserUserControl _addUser;

        public AdministrationUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<UsersService>();
            _addUser = new AddUserUserControl(_mainWindow, api);
        }

        private void AdminUsersButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_addUser);
        }
    }
}
