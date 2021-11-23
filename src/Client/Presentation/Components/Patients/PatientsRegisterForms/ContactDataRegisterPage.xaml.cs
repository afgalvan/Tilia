using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Presentation.Controllers.Http;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly MedicalDataRegisterPage    _nextPage;
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly ContextDataRetriever       _contextData;
        private readonly BasicDataRegisterPage      _lastPage;

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatient,
            ContextDataRetriever contextData, BasicDataRegisterPage lastPage)
        {
            _registerPatient = registerPatient;
            _contextData     = contextData;
            _lastPage        = lastPage;
            _nextPage        = new MedicalDataRegisterPage(registerPatient, this);
            InitializeComponent();
            PopulateFormOptions();
            ContactDataDepartmentComboBox.Loaded += OnLoadedDepartmentsCombo;
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_lastPage);
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_nextPage);
        }

        private void PopulateFormOptions()
        {
            ContactDataStratumComboBox.ComboBoxItemsSource =
                new[] { "1", "2", "3", "4", "5", "6" };
        }

        private async Task PopulateDepartments()
        {
            ContactDataDepartmentComboBox.ComboBoxItemsSource =
                await _contextData.GetDepartments(App.CancellationToken);
        }

        private async void OnLoadedDepartmentsCombo(object sender, RoutedEventArgs e)
        {
            await PopulateDepartments();
        }
    }
}
