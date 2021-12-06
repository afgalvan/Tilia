using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Components.Medical.MedicalForms;
using Presentation.Services.Http;
using Presentation.Windows;
using Requests.Appointments;
using Requests.Appointments.MedicalNotes;

namespace Presentation.Components.Medical
{
    public partial class RegisterMedicalAppointmentUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly MedicalAppointmentMainPanelUserControl _appointmentMainPanel;
        public           MedicalAppointmentRegisterPage MedicalAppointmentPage { get; set; }
        public           MedicalNoteRegisterPage MedicalNoteRegisterPage { get; set; }
        public           MedicalOrdersRegisterPage MedicalOrdersRegisterPage { get; set; }
        private readonly AppointmentsService _appointmentsService;


        public RegisterMedicalAppointmentUserControl(MainWindow mainWindow,
            AppointmentsService appointmentsService)
        {
            _mainWindow               = mainWindow;
            _appointmentsService      = appointmentsService;
            MedicalNoteRegisterPage   = new MedicalNoteRegisterPage(this);
            MedicalAppointmentPage    = new MedicalAppointmentRegisterPage(this);
            MedicalOrdersRegisterPage = new MedicalOrdersRegisterPage(this, _mainWindow);
            var api = _mainWindow.GetComponent<AppointmentsService>();
            _appointmentMainPanel =
                new MedicalAppointmentMainPanelUserControl(api, _mainWindow);
            InitializeComponent();
            FormsContentArea.Content = MedicalAppointmentPage;
        }

        public void NavigateTo(Page page)
        {
            FormsContentArea.Content = page;
        }

        // BUTTON SECTION
        private void GoBackButtonUserControl_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_appointmentMainPanel);
        }

        private void SetDefaultItemColors()
        {
            MedicalAppointmentItemButton.DefaultFormItemColors();
            MedicalNotesItemButton.DefaultFormItemColors();
            MedicalOrderItemButton.DefaultFormItemColors();
        }

        private bool IsPageInFrame(Page page)
        {
            return Equals(FormsContentArea.Content, page);
        }

        private void MedicalAppointmentItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPageInFrame(MedicalAppointmentPage))
            {
                return;
            }

            SetDefaultItemColors();
            NavigateTo(MedicalAppointmentPage);
        }

        private void MedicalNotesItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPageInFrame(MedicalNoteRegisterPage))
            {
                return;
            }

            SetDefaultItemColors();
            MedicalAppointmentItemButton.CompletedFormItemColors();
            NavigateTo(MedicalNoteRegisterPage);
        }

        private void MedicalOrderItemButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (IsPageInFrame(MedicalOrdersRegisterPage))
            {
                return;
            }

            MedicalAppointmentItemButton.CompletedFormItemColors();
            MedicalNotesItemButton.CompletedFormItemColors();
            NavigateTo(MedicalOrdersRegisterPage);
        }

        private MedicalNoteDto CreateMedicalNote()
        {
            return new MedicalNoteDto
            {
                EvolutionSheet  = MedicalNoteRegisterPage.GetEvolutionSheetText(),
                ManagementPlans = MedicalNoteRegisterPage.GetManagementPlans(),
                Diagnostics     = MedicalOrdersRegisterPage.GetDiagnoses(),
                Referrals       = MedicalOrdersRegisterPage.GetReferrals(),
            };
        }

        private CreateMedicalAppointmentRequest CreateMedicalRequest()
        {
            return new CreateMedicalAppointmentRequest
            {
                AppointmentReason    = MedicalAppointmentPage.GetAppointmentReason(),
                DiseaseHistory       = MedicalAppointmentPage.GetDiseaseHistory(),
                AppointmentDate      = MedicalAppointmentPage.GetAppointmentDate(),
                AnamnesisDescription = MedicalAppointmentPage.GetAnamnesis(),
                MedicalNote          = CreateMedicalNote(),
                PatientId            = MedicalAppointmentPage.GetPatientId(),
                DoctorId             = MedicalAppointmentPage.GetDoctorId()
            };
        }

        public async Task CreateMedicalAppointment()
        {
            await _appointmentsService.RegisterAppointment(CreateMedicalRequest(),
                App.CancellationToken);
            await ShowMessageOnSuccess();
            ChangeContentOnComplete(
                new MedicalAppointmentMainPanelUserControl(_appointmentsService,
                    _mainWindow));
        }

        public virtual async void FinishFormItemButton_OnClick(object sender,
            RoutedEventArgs e)
        {
            await CreateMedicalAppointment();
        }

        private async Task ShowCustomMessage(string title, string text)
        {
            await _mainWindow.ShowMessageAsync(title, text);
        }


        private async Task ShowMessageOnSuccess()
        {
            await ShowCustomMessage("Exito",
                "Consulta creada correctamente");
        }

        private void ChangeContentOnComplete(UserControl userControl)
        {
            _mainWindow.ChangeMainContentArea(userControl);
        }
    }
}
