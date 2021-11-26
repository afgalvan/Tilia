using System.Threading.Tasks;
using System.Windows;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class PatientsUserControl
    {
        private readonly MainWindow                 _mainWindow;
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly PatientService             _patientService;

        public PatientsUserControl(MainWindow mainWindow, PatientService patientService)
        {
            _mainWindow     = mainWindow;
            _patientService = patientService;
            InitializeComponent();
            _registerPatient = new RegisterPatientUserControl(_mainWindow, _patientService);
            PatientsDataGrid.Loaded += LoadTableInformation;
        }

        private void AddPatientButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_registerPatient);
        }

        private async void LoadTableInformation(object sender, RoutedEventArgs e)
        {
            PatientsDataGrid.ItemsSource =
                await _patientService.GetAllPatients(App.CancellationToken);
        }
    }
}
