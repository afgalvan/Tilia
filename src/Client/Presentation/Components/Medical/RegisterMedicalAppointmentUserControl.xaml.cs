using System.Windows.Controls;
using Presentation.Components.Medical.MedicalForms;

namespace Presentation.Components.Medical
{
    public partial class RegisterMedicalAppointmentUserControl : UserControl
    {
        public MedicalAppointmentRegisterPage MedicalAppointmentPage { get; set; }
        public MedicalNoteRegisterPage MedicalNoteRegisterPage { get; set; }


        public RegisterMedicalAppointmentUserControl()
        {
            MedicalNoteRegisterPage = new MedicalNoteRegisterPage();
            MedicalAppointmentPage = new MedicalAppointmentRegisterPage(this);
            InitializeComponent();
            FormsContentArea.Content = MedicalAppointmentPage;
        }

        public void NavigateTo(Page page)
        {
            FormsContentArea.Content = page;
        }
    }
}
