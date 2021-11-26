using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Dashboard;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class PatientsUserControl
    {
        private readonly MainWindow                 _mainWindow;
        private readonly RegisterPatientUserControl _registerPatient;

        public PatientsUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<PatientService>();
            _registerPatient = new RegisterPatientUserControl(_mainWindow, api);
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_registerPatient);
        }
    }
}
