using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Presentation.Controllers.Http;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly MedicalDataRegisterPage _nextPage;
        private readonly ContextDataRetriever    _contextData;

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatientUserControl,
            ContextDataRetriever contextData)
        {
            _contextData = contextData;
            _nextPage    = new MedicalDataRegisterPage(registerPatientUserControl, this);
            InitializeComponent();
            PopulateFormOptions();
            ContactDataDepartmentComboBox.Loaded += OnLoadedDepartmentsCombo;
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
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
