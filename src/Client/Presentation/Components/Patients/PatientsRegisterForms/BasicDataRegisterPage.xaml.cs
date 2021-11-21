using System.Windows.Controls;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class BasicDataRegisterPage : Page
    {
        private readonly PatientsRegisterUserControl _patientsRegisterUserControl;
        private readonly ContactDataRegisterPage _nextPage;

        public BasicDataRegisterPage(PatientsRegisterUserControl patientsRegisterUserControl)
        {
            _nextPage = new ContactDataRegisterPage(patientsRegisterUserControl, this);
            _patientsRegisterUserControl = patientsRegisterUserControl;
            InitializeComponent();
            PopulateFormOptions();
        }

        private void GoToNextPageButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _patientsRegisterUserControl.NavigateTo(_nextPage);
        }

        private void PopulateFormOptions()
        {
            BasicDataDocTypeComboBox.ComboBoxItemsSource = new[] { "Cedula", "Tarjeta de identidad", "Pasaporte", "Cedula extranjera" };
            BasicDataGenreComboBox.ComboBoxItemsSource = new[] { "Masculino", "Femenino" };
        }
    }
}
