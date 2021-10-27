using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Administration.Users
{
    /// <summary>
    /// Interaction logic for AddUserUserControl.xaml
    /// </summary>
    public partial class AddUserUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;

        public AddUserUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void BackToAdminUserControlButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
        }
    }
}
