using System;
using System.Collections;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Domain.Locations;
using Presentation.Controllers.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class BasicDataRegisterPage : Page
    {
        private readonly MainWindow                 _mainWindow;
        private readonly ContextDataRetriever       _contextData;
        private readonly RegisterPatientUserControl _registerPatient;
        private          IEnumerable                Departments { get; set; }
        private          IEnumerable                Cities      { get; set; }

        public BasicDataRegisterPage(MainWindow mainWindow, ContextDataRetriever contextData,
            RegisterPatientUserControl registerPatient)
        {
            _mainWindow      = mainWindow;
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
            var nextPage = new ContactDataRegisterPage(_registerPatient, _contextData, this);
            _registerPatient.NavigateTo(nextPage);
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
            await PopulateCities();
        }

        private async Task PopulateCities()
        {
            if (GetSelectedDepartment() == null)
            {
                BasicDataBirthPlaceComboBox.ComboBoxItemsSource = new[] { "Sin conexión con el servidor" };
                return;
            }

            string departmentId = GetSelectedDepartment().Id;
            Cities = await _contextData.GetCities(departmentId, App.CancellationToken);
            BasicDataBirthPlaceComboBox.ComboBoxItemsSource = Cities;
            BasicDataBirthPlaceComboBox.ComboBoxSelectedIndex = "0";
        }
    }
}
