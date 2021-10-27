using Presentation.Components.Administration.Users;
using Presentation.Windows;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Administration
{
    /// <summary>
    /// Interaction logic for AdministrationUserControl.xaml
    /// </summary>
    public partial class AdministrationUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;

        public AdministrationUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void ManageUserButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AddUserUserControl(_mainWindow));
        }
    }
}
