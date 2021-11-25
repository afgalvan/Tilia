using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Patients.PatientsRegisterForms;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class RegisterPatientUserControl
    {
        private readonly MainWindow              _mainWindow;
        public BasicDataRegisterPage   BasicDataRegister { get; set;}
        public ContactDataRegisterPage ContactDataRegister {get; set;}
        public MedicalDataRegisterPage MedicalDataRegister {get; set;}

        public RegisterPatientUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<ContextDataRetriever>();
            BasicDataRegister = new BasicDataRegisterPage(api, this);
            ContactDataRegister = new ContactDataRegisterPage(this, api);
            MedicalDataRegister = new MedicalDataRegisterPage(this);
            FormsContentArea.Content = BasicDataRegister;
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
            if (IsPageInFrame(BasicDataRegister))
            {
                return;
            }

            SetDefaultItemColors();
            NavigateTo(BasicDataRegister);
        }

        private void ContactDataItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Equals(FormsContentArea.Content, ContactDataRegister))
            {
                return;
            }

            SetDefaultItemColors();
            BasicDataItemButton.CompletedFormItemColors();
            NavigateTo(ContactDataRegister);
        }

        private void MedicalDataItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Equals(FormsContentArea.Content, MedicalDataRegister))
            {
                return;
            }

            BasicDataItemButton.CompletedFormItemColors();
            ContactDataItemButton.CompletedFormItemColors();
            NavigateTo(MedicalDataRegister);
        }
    }
}
