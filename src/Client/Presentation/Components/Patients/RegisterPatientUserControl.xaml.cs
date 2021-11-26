using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Patients.PatientsRegisterForms;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class RegisterPatientUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;

        public RegisterPatientUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<ContextDataRetriever>();
            FormsContentArea.Content = new BasicDataRegisterPage(api, this);
        }

        private void GoBackButtonUserControl_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new PatientsUserControl(_mainWindow));
        }

        public void NavigateTo(Page page)
        {
            FormsContentArea.Content = page;
        }
    }
}
