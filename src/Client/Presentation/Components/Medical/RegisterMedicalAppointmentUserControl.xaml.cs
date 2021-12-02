using System.Windows;
using System.Windows.Controls;
using Presentation.Components.Medical.MedicalForms;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Medical
{
    public partial class RegisterMedicalAppointmentUserControl : UserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly MedicalAppointmentMainPanelUserControl _appointmentMainPanel;
        public MedicalAppointmentRegisterPage MedicalAppointmentPage { get; set; }
        public MedicalNoteRegisterPage MedicalNoteRegisterPage { get; set; }
        public MedicalOrdersRegisterPage MedicalOrdersRegisterPage { get; set; }


        public RegisterMedicalAppointmentUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            MedicalNoteRegisterPage = new MedicalNoteRegisterPage(this);
            MedicalAppointmentPage = new MedicalAppointmentRegisterPage(this);
            MedicalOrdersRegisterPage = new MedicalOrdersRegisterPage(this, _mainWindow);
            var api = _mainWindow.GetComponent<AppointmentsService>();
            _appointmentMainPanel = new MedicalAppointmentMainPanelUserControl(api, _mainWindow);
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
    }
}
