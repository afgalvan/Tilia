using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Patients.PatientsRegisterForms;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients
{
    public partial class RegisterPatientUserControl
    {
        private readonly PatientService          _patientService;
        private readonly MainWindow              _mainWindow;
        public           BasicDataRegisterPage   BasicDataRegister   { get; set; }
        public           ContactDataRegisterPage ContactDataRegister { get; set; }
        public           SportDataRegisterPage   SportDataRegister   { get; set; }

        public RegisterPatientUserControl(MainWindow mainWindow, PatientService patientService)
        {
            _mainWindow     = mainWindow;
            _patientService = patientService;
            InitializeComponent();
            var api = _mainWindow.GetComponent<ContextDataRetriever>();
            BasicDataRegister        = new BasicDataRegisterPage(api, this, _mainWindow);
            ContactDataRegister      = new ContactDataRegisterPage(this, api, _mainWindow);
            SportDataRegister        = new SportDataRegisterPage(this, _mainWindow, _patientService);
            FormsContentArea.Content = BasicDataRegister;
        }

        private void GoBackButtonUserControl_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new PatientsUserControl(_mainWindow, _patientService));
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
            if (Equals(FormsContentArea.Content, SportDataRegister))
            {
                return;
            }

            BasicDataItemButton.CompletedFormItemColors();
            ContactDataItemButton.CompletedFormItemColors();
            NavigateTo(SportDataRegister);
        }

        public async Task CreatePatient()
        {
            await _patientService.RegisterPatient(BasicDataRegister.GetPersonId(),
                BasicDataRegister.GetSelectedIdTypeNumber(),
                BasicDataRegister.GetFirstName(),
                BasicDataRegister.GetLastName(),
                BasicDataRegister.GetSelectedGenreNumber(),
                BasicDataRegister.GetCityCode(),
                BasicDataRegister.GetBirthDate(),
                BasicDataRegister.GetOccupation(),
                ContactDataRegister.GetStudies(),
                SportDataRegister.GetSport(),
                SportDataRegister.GetModality(),
                SportDataRegister.GetCoach(),
                SportDataRegister.GetStartDate(),
                SportDataRegister.GetContinuousTraining(),
                SportDataRegister.GetTrainingPlan(),
                SportDataRegister.GetSelectedDominanceNumber(),
                ContactDataRegister.GetAddress(),
                ContactDataRegister.GetLivingCityCode(),
                ContactDataRegister.GetSelectedStratumNumber(),
                ContactDataRegister.GetPhoneNumber(),
                ContactDataRegister.GetLandLine(),
                App.CancellationToken);
        }
    }
}
