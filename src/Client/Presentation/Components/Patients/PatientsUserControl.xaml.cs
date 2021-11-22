using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Dashboard;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class PatientsUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;

        public PatientsUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new RegisterPatientUserControl(_mainWindow));
        }
    }
}
