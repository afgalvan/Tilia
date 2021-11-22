using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly RegisterPatientUserControl _registerPatientUserControl;

        // private readonly BasicDataRegisterPage _basicDataRegisterPage;
        private readonly MedicalDataRegisterPage _nextPage;

        public ContactDataRegisterPage(RegisterPatientUserControl registerPatientUserControl
            // BasicDataRegisterPage basicDataRegisterPage)
        )
        {
            _nextPage = new MedicalDataRegisterPage(registerPatientUserControl, this);
            // _basicDataRegisterPage = basicDataRegisterPage;
            _registerPatientUserControl = registerPatientUserControl;
            InitializeComponent();
            PopulateFormOptions();
        }

        private void GoBackToPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            // _registerPatientUserControl.NavigateTo(_basicDataRegisterPage);
        }

        private void GoToNextPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _registerPatientUserControl.NavigateTo(_nextPage);
        }

        private void PopulateFormOptions()
        {
            ContactDataStratumComboBox.ComboBoxItemsSource =
                new[] { "1", "2", "3", "4", "5", "6" };
        }
    }
}
