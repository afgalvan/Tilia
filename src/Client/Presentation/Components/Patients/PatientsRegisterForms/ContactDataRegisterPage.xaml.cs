using Domain.Locations;
using System.Collections;
using System.Threading.Tasks;
using System.Windows;
using Presentation.Services.Http;
using Convert = Presentation.Utils.Convert;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage
    {
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly ContextDataRetriever       _contextData;
        private          IEnumerable                Departments { get; set; }
        private          IEnumerable                Cities      { get; set; }

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatient,
            ContextDataRetriever contextData)
        {
            _registerPatient = registerPatient;
            _contextData     = contextData;
            InitializeComponent();
            ContactDataDepartmentComboBox.OnSelectionChangedAction =  PopulateCities;
            ContactDataDepartmentComboBox.OnDropDownClosedAction   =  PopulateCities;
            Loaded                                                 += OnLoadedPage;
            ContactDataDepartmentComboBox.Loaded                   += OnLoadedDepartmentsCombo;
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_registerPatient.BasicDataRegister);
            _registerPatient.ContactDataItemButton.DefaultFormItemColors();
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_registerPatient.SportDataRegister);
            _registerPatient.ContactDataItemButton.CompletedFormItemColors();
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            PopulateSyncOptions();
            _registerPatient.ContactDataItemButton.CurrentFormItemColors();
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
        }

        public string GetLivingCityCode() => ((City)ContactDataCityComboBox.ComboBoxSelectedItem).Id;

        public int GetSelectedStratumNumber()
        {
            return Convert.StringToInt(ContactDataStratumComboBox.FieldText);
        }

        public string GetAddress() => ContactDataAddressTextBox.FieldText;

        public string GetStudies() => ContactDataStudiesTextBox.FieldText;

        public string GetLandLine() => ContactDataLandlineTextBox.FieldText;

        public string GetPhoneNumber() => ContactDataPhoneNumberTextBox.FieldText;
    }
}
