using System.Windows;
using Presentation.Components.Atomic.Input;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class MedicalDataRegisterPage
    {
        private readonly RegisterPatientUserControl _registerPatient;

        public MedicalDataRegisterPage(RegisterPatientUserControl registerPatientUserControl)
        {
            _registerPatient = registerPatientUserControl;
            InitializeComponent();
            PopulateFormOptions();
            Loaded += OnLoadedPage;
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItemButton.CurrentFormItemColors();
        }

        private void FinishRegisterPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItemButton.CompletedFormItemColors();
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_registerPatient.ContactDataRegister);
            _registerPatient.MedicalDataItemButton.DefaultFormItemColors();
        }

        private void PopulateFormOptions()
        {
            var hasOptions = new [] { "Tiene", "No tiene" };
            MedicalDataDominanceComboBox.ComboBoxItemsSource = new[] { "Diestro", "Zurdo" };
            MedicalTrainingPlanComboBox.ComboBoxItemsSource = hasOptions;
            MedicalContinuousTrainingComboBox.ComboBoxItemsSource = hasOptions;
        }

        private bool GetBooleanOptions(ComboBoxUserControl comboBox)
        {
            return comboBox.FieldText.Equals("Tiene");
        }
    }
}
