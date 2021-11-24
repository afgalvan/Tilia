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
        private readonly BasicDataRegisterPage _basicDataRegister;
        private readonly ContactDataRegisterPage _contactDataRegister;
        private readonly MedicalDataRegisterPage _medicalDataRegister;

        public RegisterPatientUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<ContextDataRetriever>();
            _basicDataRegister = new BasicDataRegisterPage(_mainWindow, api, this);
            _contactDataRegister = new ContactDataRegisterPage(this, api, _basicDataRegister);
            _medicalDataRegister = new MedicalDataRegisterPage(this, _contactDataRegister);
            FormsContentArea.Content = _basicDataRegister;
        }

        private void GoBackButtonUserControl_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new PatientsUserControl(_mainWindow));
        }

        public void NavigateTo(Page page)
        {
            FormsContentArea.Content = page;
        }

        private void SetDefaultItemColors()
        {
            BasicDataItemButton.DefaultFormItemColors();
            ContactDataItemButton.DefaultFormItemColors();
            MedicalDataItemButton.DefaultFormItemColors();
        }

        private bool IsPageInFrame(Page page)
        {
            return Equals(FormsContentArea.Content, page);
        }

        private void BasicDataItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPageInFrame(_basicDataRegister))
            {
                return;
            }

            SetDefaultItemColors();
            NavigateTo(_basicDataRegister);
        }

        private void ContactDataItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Equals(FormsContentArea.Content, _contactDataRegister))
            {
                return;
            }

            SetDefaultItemColors();
            BasicDataItemButton.CompletedFormItemColors();
            NavigateTo(_contactDataRegister);
        }

        private void MedicalDataItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Equals(FormsContentArea.Content, _medicalDataRegister))
            {
                return;
            }

            BasicDataItemButton.CompletedFormItemColors();
            ContactDataItemButton.CompletedFormItemColors();
            NavigateTo(_medicalDataRegister);
        }
    }
}
