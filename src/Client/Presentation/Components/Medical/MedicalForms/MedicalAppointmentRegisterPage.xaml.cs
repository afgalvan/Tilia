using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalAppointmentRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;

        public MedicalAppointmentRegisterPage(RegisterMedicalAppointmentUserControl registerMedicalAppointment)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            InitializeComponent();
        }


        private void GoToNextPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment.MedicalNoteRegisterPage);
        }
    }
}
