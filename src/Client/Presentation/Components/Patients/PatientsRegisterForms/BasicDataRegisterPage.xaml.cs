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
        private readonly MainWindow           _mainWindow;
        private readonly ContextDataRetriever _contextData;
        private          IEnumerable          Departments { get; set; }
        private          IEnumerable          Cities      { get; set; }

        public BasicDataRegisterPage(MainWindow mainWindow, ContextDataRetriever contextData)
        {
            _mainWindow  = mainWindow;
            _contextData = contextData;
            InitializeComponent();
            BasicDataDepartmentComboBox.OnSelectionChangedAction =  PopulateCities;
            BasicDataDepartmentComboBox.OnDropDownClosedAction   =  PopulateCities;
            Loaded                                               += OnLoadedPage;
            BasicDataDocTypeComboBox.Loaded                      += OnLoadedIdCombo;
            BasicDataDepartmentComboBox.Loaded                   += OnLoadedDepartmentsCombo;
            BasicDataBirthPlaceComboBox.Loaded                    += OnLoadedCitiesCombo;
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
                await Task.Delay(500);
            }
            string departmentId = GetSelectedDepartment().Id;
            Cities = await _contextData.GetCities(departmentId, App.CancellationToken);
            BasicDataBirthPlaceComboBox.ComboBoxItemsSource = Cities;
            BasicDataBirthPlaceComboBox.ComboBoxSelectedIndex = "0";
        }

        private async void OnLoadedCitiesCombo(object sender, RoutedEventArgs e)
        {
            await PopulateCities();
        }
    }
}
