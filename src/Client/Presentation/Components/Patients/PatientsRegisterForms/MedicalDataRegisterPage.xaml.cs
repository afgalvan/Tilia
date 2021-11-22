using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class MedicalDataRegisterPage : Page
    {
        private readonly RegisterPatientUserControl _registerPatientUserControl;
        private readonly ContactDataRegisterPage _contactDataRegisterPage;

        public MedicalDataRegisterPage(RegisterPatientUserControl registerPatientUserControl, ContactDataRegisterPage contactDataRegisterPage)
        {
            _contactDataRegisterPage = contactDataRegisterPage;
            _registerPatientUserControl = registerPatientUserControl;
            InitializeComponent();
            PopulateFormOptions();
        }

        private void FinishRegisterPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void GoBackToPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _registerPatientUserControl.NavigateTo(_contactDataRegisterPage);
        }

        private void PopulateFormOptions()
        {
            MedicalDataDominanceComboBox.ComboBoxItemsSource = new[] { "Diestro", "Zurdo" };
        }
    }
}
