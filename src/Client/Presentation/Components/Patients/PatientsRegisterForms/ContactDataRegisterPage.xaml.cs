using System.Collections;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Domain.Locations;
using Presentation.Controllers.Http;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly MedicalDataRegisterPage    _nextPage;
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly ContextDataRetriever       _contextData;
        private readonly BasicDataRegisterPage      _lastPage;
        private          IEnumerable                Departments { get; set; }
        private          IEnumerable                Cities      { get; set; }

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatient,
            ContextDataRetriever contextData, BasicDataRegisterPage lastPage)
        {
            _registerPatient = registerPatient;
            _contextData     = contextData;
            _lastPage        = lastPage;
            _nextPage        = new MedicalDataRegisterPage(registerPatient, this);
            InitializeComponent();
            ContactDataDepartmentComboBox.OnSelectionChangedAction =  PopulateCities;
            ContactDataDepartmentComboBox.OnDropDownClosedAction   =  PopulateCities;
            Loaded                                                 += OnLoadedPage;
            ContactDataDepartmentComboBox.Loaded                   += OnLoadedDepartmentsCombo;
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_lastPage);
            _registerPatient.BasicDataItem.CurrentFormItemColors();
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_nextPage);
            _registerPatient.ContactDataItem.CompletedFormItemColors();
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            PopulateSyncOptions();
            _registerPatient.ContactDataItem.CurrentFormItemColors();
        }

        private void PopulateSyncOptions()
        {
            ContactDataStratumComboBox.ComboBoxItemsSource =
                new[] { "1", "2", "3", "4", "5", "6" };
        }

        private async Task PopulateDepartments()
        {
            Departments ??= await _contextData.GetDepartments(App.CancellationToken);
            ContactDataDepartmentComboBox.ComboBoxItemsSource = Departments;
        }

        private Department GetSelectedDepartment()
        {
            return (Department)ContactDataDepartmentComboBox.ComboBoxSelectedItem;
        }

        private async Task PopulateCities()
        {
            if (GetSelectedDepartment() == null)
            {
                ContactDataCityComboBox.ComboBoxItemsSource =
                    new[] { "Sin conexión con el servidor" };
                return;
            }

            string departmentId = GetSelectedDepartment().Id;
            Cities = await _contextData.GetCities(departmentId, App.CancellationToken);
            ContactDataCityComboBox.ComboBoxItemsSource = Cities;
            ContactDataCityComboBox.ComboBoxSelectedIndex = "0";
        }

        private async void OnLoadedDepartmentsCombo(object sender, RoutedEventArgs e)
        {
            await PopulateDepartments();
            await PopulateCities();
        }
    }
}
