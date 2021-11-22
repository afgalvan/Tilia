using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly MedicalDataRegisterPage _nextPage;

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatientUserControl)
        {
            _nextPage = new MedicalDataRegisterPage(registerPatientUserControl, this);
            InitializeComponent();
            PopulateFormOptions();
        }

        private void GoBackToPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void GoToNextPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void PopulateFormOptions()
        {
            ContactDataStratumComboBox.ComboBoxItemsSource =
                new[] { "1", "2", "3", "4", "5", "6" };
        }
    }
}
