using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class MedicalDataRegisterPage : Page
    {
        private readonly PatientsRegisterUserControl _patientsRegisterUserControl;
        private readonly ContactDataRegisterPage _contactDataRegisterPage;

        public MedicalDataRegisterPage(PatientsRegisterUserControl patientsRegisterUserControl, ContactDataRegisterPage contactDataRegisterPage)
        {
            _contactDataRegisterPage = contactDataRegisterPage;
            _patientsRegisterUserControl = patientsRegisterUserControl;
            InitializeComponent();
            PopulateFormOptions();
        }

        private void FinishRegisterPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void GoBackToPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _patientsRegisterUserControl.NavigateTo(_contactDataRegisterPage);
        }

        private void PopulateFormOptions()
        {
            MedicalDataDominanceComboBox.ComboBoxItemsSource = new[] { "Diestro", "Zurdo" };
        }
    }
}
