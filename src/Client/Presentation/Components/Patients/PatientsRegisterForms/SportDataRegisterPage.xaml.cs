using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Services.Http;
using Presentation.Utils;
using Presentation.Windows;
using Convert = Presentation.Utils.Convert;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class SportDataRegisterPage
    {
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly MainWindow                 _mainWindow;
        private readonly PatientService             _patientService;

        public SportDataRegisterPage(RegisterPatientUserControl registerPatientUserControl,
            MainWindow mainWindow, PatientService patientService)
        {
            _registerPatient     = registerPatientUserControl;
            _mainWindow          = mainWindow;
            _patientService = patientService;
            InitializeComponent();
            PopulateFormOptions();
            Loaded += OnLoadedPage;
            SportDataStartDateDatePicker.EndDate = DateTime.Now;
        }

        private void ChangeContentOnComplete(UserControl userControl)
        {
            _mainWindow.ChangeMainContentArea(userControl);
        }

        private async Task ShowCustomMessage(string title, string text)
        {
            await _mainWindow.ShowMessageAsync(title, text);
        }

        private async Task ShowMessageOnSuccess()
        {
            await ShowCustomMessage("Exito",
                "Paciente creado correctamente");
        }

        private async Task CreatePatient()
        {
            try
            {
                await _registerPatient.CreatePatient();
                _registerPatient.FinishFormItemButton.CompletedFormItemColors();
                await ShowMessageOnSuccess();
                _mainWindow.ChangeMainContentArea(new PatientsUserControl(_mainWindow, _patientService));
            }
            catch (Exception e)
            {
                await ShowCustomMessage("Error", e.Message);
            }
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItemButton.CurrentFormItemColors();
        }

        private async void FinishRegisterPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItemButton.CompletedFormItemColors();
            if (Ensure.AreAllFieldsCompleted(SportDataTrainingPlanComboBox.FieldText,
                SportDataContinuousTrainingComboBox.FieldText,
                SportDataDominanceComboBox.FieldText,
                SportDataSportTextBox.FieldText,
                SportDataModalityTextBox.FieldText,
                SportDataCoachTextBox.FieldText,
                SportDataStartDateDatePicker.FieldText))
            {
                await CreatePatient();
                return;
            }

            await ShowCustomMessage("Error al crear el usuario",
                "Llene los campos vacios");
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_registerPatient.ContactDataRegister);
            _registerPatient.MedicalDataItemButton.DefaultFormItemColors();
        }

        private void PopulateFormOptions()
        {
            var hasOptions = new[] { "Tiene", "No tiene" };
            SportDataDominanceComboBox.ComboBoxItemsSource = new[] { "Diestro", "Zurdo" };
            SportDataTrainingPlanComboBox.ComboBoxItemsSource = hasOptions;
            SportDataContinuousTrainingComboBox.ComboBoxItemsSource = hasOptions;
        }

        private static bool GetBooleanOption(string comboBoxOption)
        {
            return comboBoxOption.Equals("Tiene", StringComparison.Ordinal);
        }

        public bool GetTrainingPlan()
        {
            return GetBooleanOption(SportDataTrainingPlanComboBox.FieldText);
        }

        public bool GetContinuousTraining()
        {
            return GetBooleanOption(SportDataContinuousTrainingComboBox.FieldText);
        }

        public int GetSelectedDominanceNumber()
        {
            return Convert.StringToInt(SportDataDominanceComboBox.ComboBoxSelectedIndex);
        }

        public string GetSport() => SportDataSportTextBox.FieldText;

        public string GetModality() => SportDataModalityTextBox.FieldText;

        public string GetCoach() => SportDataCoachTextBox.FieldText;

        public DateTime GetStartDate()
        {
            return Convert.StringToDateTime(SportDataStartDateDatePicker.FieldText);
        }
    }
}
