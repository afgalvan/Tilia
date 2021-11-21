using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class ContactDataRegisterPage : Page
    {
        private readonly PatientsRegisterUserControl _patientsRegisterUserControl;
        private readonly BasicDataRegisterPage _basicDataRegisterPage;
        private readonly MedicalDataRegisterPage _nextPage;

        public ContactDataRegisterPage(PatientsRegisterUserControl patientsRegisterUserControl, BasicDataRegisterPage basicDataRegisterPage)
        {
            _nextPage = new MedicalDataRegisterPage(patientsRegisterUserControl, this);
            _basicDataRegisterPage = basicDataRegisterPage;
            _patientsRegisterUserControl = patientsRegisterUserControl;
            InitializeComponent();
            PopulateFormOptions();
        }

        private void GoBackToPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _patientsRegisterUserControl.NavigateTo(_basicDataRegisterPage);
        }

        private void GoToNextPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _patientsRegisterUserControl.NavigateTo(_nextPage);
        }

        private void PopulateFormOptions()
        {
            ContactDataStratumComboBox.ComboBoxItemsSource = new[] { "1", "2", "3", "4", "5", "6" };
        }
    }
}
