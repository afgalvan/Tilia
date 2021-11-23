using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Presentation.Controllers.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class BasicDataRegisterPage : Page
    {
        private readonly MainWindow           _mainWindow;
        private readonly ContextDataRetriever _contextData;

        public BasicDataRegisterPage(MainWindow mainWindow, ContextDataRetriever contextData)
        {
            _mainWindow  = mainWindow;
            _contextData = contextData;
            InitializeComponent();
            Loaded                             += OnLoadedPage;
            BasicDataDocTypeComboBox.Loaded    += OnLoadedIdCombo;
            BasicDataDepartmentComboBox.Loaded += OnLoadedDepartmentsCombo;
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            var registerPatient = new RegisterPatientUserControl(_mainWindow);
            var nextPage        = new ContactDataRegisterPage(registerPatient, _contextData);
            registerPatient.NavigateTo(nextPage);
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            PopulateSyncOptions();
        }

        private void PopulateSyncOptions()
        {
            BasicDataGenreComboBox.ComboBoxItemsSource = new[] { "Masculino", "Femenino" };
        }

        private async Task PopulateIdTypes()
        {
            BasicDataDocTypeComboBox.ComboBoxItemsSource =
                await _contextData.GetIdTypes(App.CancellationToken);
        }

        private async void OnLoadedIdCombo(object sender, RoutedEventArgs e)
        {
            await PopulateIdTypes();
        }

        private async Task PopulateDepartments()
        {
            BasicDataDepartmentComboBox.ComboBoxItemsSource =
                await _contextData.GetDepartments(App.CancellationToken);
        }

        private async void OnLoadedDepartmentsCombo(object sender, RoutedEventArgs e)
        {
            await PopulateDepartments();
        }
    }
}
