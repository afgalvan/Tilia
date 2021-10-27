using Presentation.Components.Administration.Users;
using Presentation.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Administration
{
    /// <summary>
    /// Interaction logic for AdmistrationUserControl.xaml
    /// </summary>
    public partial class AdmistrationUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;

        public AdmistrationUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public AdmistrationUserControl()
        {
            InitializeComponent();
        }

        private void MangeUserButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AddUserUserControl());
        }
    }
}
