using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class MedicalDataRegisterPage : Page
    {
        private readonly RegisterPatientUserControl _registerPatient;
        private readonly ContactDataRegisterPage _contactDataRegisterPage;

        public MedicalDataRegisterPage(RegisterPatientUserControl registerPatientUserControl, ContactDataRegisterPage contactDataRegisterPage)
        {
            _contactDataRegisterPage = contactDataRegisterPage;
            _registerPatient = registerPatientUserControl;
            InitializeComponent();
            PopulateFormOptions();
            Loaded += OnLoadedPage;
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItem.CurrentFormItemColors();
        }

        private void FinishRegisterPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.MedicalDataItem.CompletedFormItemColors();
        }

        private void GoBackToPageButton_Click(object sender, RoutedEventArgs e)
        {
            _registerPatient.NavigateTo(_contactDataRegisterPage);
        }

        private void PopulateFormOptions()
        {
            MedicalDataDominanceComboBox.ComboBoxItemsSource = new[] { "Diestro", "Zurdo" };
        }
    }
}
