using System;
using System.Collections;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using Domain.Locations;
using Domain.People;
using Presentation.Services.Http;
using Presentation.Utils;
using Convert = Presentation.Utils.Convert;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class BasicDataRegisterPage
    {
        private readonly ContextDataRetriever       _contextData;
        private readonly RegisterPatientUserControl _registerPatient;

        private IEnumerable Departments { get; set; }
        private IEnumerable Cities      { get; set; }
        private IEnumerable IdTypes     { get; set; }

        public BasicDataRegisterPage(ContextDataRetriever contextData,
            RegisterPatientUserControl registerPatient)
        {
            _contextData     = contextData;
            _registerPatient = registerPatient;
            InitializeComponent();
            BasicDataDepartmentComboBox.OnSelectionChangedAction =  PopulateCities;
            BasicDataDepartmentComboBox.OnDropDownClosedAction   =  PopulateCities;
            Loaded                                               += OnLoadedPage;
            BasicDataDocTypeComboBox.Loaded                      += OnLoadedIdCombo;
            BasicDataDepartmentComboBox.Loaded                   += OnLoadedDepartmentsCombo;
            BasicDataBirthDayDatePicker.EndDate                  =  DateTime.Now;
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_registerPatient.ContactDataRegister);
            _registerPatient.BasicDataItemButton.CompletedFormItemColors();
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            PopulateSyncOptions();
            _registerPatient.BasicDataItemButton.CurrentFormItemColors();
        }

        private void PopulateSyncOptions()
        {
            BasicDataGenreComboBox.ComboBoxItemsSource = new[] { "Masculino", "Femenino" };
        }

        private async Task PopulateIdTypes()
        {
            IdTypes ??= await _contextData.GetIdTypes(App.CancellationToken);
            BasicDataDocTypeComboBox.ComboBoxItemsSource = IdTypes;
        }

        private async void OnLoadedIdCombo(object sender, RoutedEventArgs e)
        {
            await PopulateIdTypes();
        }

        private async Task PopulateDepartments()
        {
            Departments ??= await _contextData.GetDepartments(App.CancellationToken);
            BasicDataDepartmentComboBox.ComboBoxItemsSource = Departments;
        }

        private Department GetSelectedDepartment()
        {
            return (Department)BasicDataDepartmentComboBox.ComboBoxSelectedItem;
        }

        private async void OnLoadedDepartmentsCombo(object sender, RoutedEventArgs e)
        {
            await PopulateDepartments();
        }

        private async Task PopulateCities()
        {
            if (GetSelectedDepartment() == null)
            {
                BasicDataBirthPlaceComboBox.ComboBoxItemsSource =
                    new[] { "Sin conexión con el servidor" };
                return;
            }

            string departmentId = GetSelectedDepartment().Id;
            Cities = await _contextData.GetCities(departmentId, App.CancellationToken);
            BasicDataBirthPlaceComboBox.ComboBoxItemsSource = Cities;
            BasicDataBirthPlaceComboBox.ComboBoxSelectedIndex = "0";
        }

        private IdType GetSelectedIdType() => (IdType)BasicDataDocTypeComboBox.ComboBoxSelectedItem;

        public int GetSelectedIdTypeNumber()
        {
            var selectedId = GetSelectedIdType();
            return selectedId.Id;
        }

        public string GetPersonId() => BasicDataDataNumberTextBox.FieldText;

        public int GetSelectedGenreNumber()
        {
            return Convert.StringToInt(BasicDataGenreComboBox.ComboBoxSelectedIndex);
        }

        public string GetFirstName() => BasicDataNamesTextBox.FieldText;

        public string GetLastName() => BasicDataLastNamesTextBox.FieldText;

        public string GetOccupation() => BasicDataChargeTextBox.FieldText;

        public DateTime GetBirthDate()
        {
            return Convert.StringToDateTime(BasicDataBirthDayDatePicker.FieldText);
        }

        public string GetCityCode() => ((City)BasicDataBirthPlaceComboBox.ComboBoxSelectedItem).Id;
    }
}
