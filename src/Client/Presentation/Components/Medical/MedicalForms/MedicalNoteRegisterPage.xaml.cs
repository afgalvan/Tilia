using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Requests.Appointments.MedicalNotes;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalNoteRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;

        private readonly IList<ManagementPlanDto> _managementsPlans;

        public MedicalNoteRegisterPage(
            RegisterMedicalAppointmentUserControl registerMedicalAppointment)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            InitializeComponent();
            Loaded            += OnLoadedPage;
            _managementsPlans =  new List<ManagementPlanDto>();
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalNotesItemButton.CurrentFormItemColors();
        }

        private void GoBackToPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment
                .MedicalAppointmentPage);
            _registerMedicalAppointment.MedicalNotesItemButton.DefaultFormItemColors();
        }

        private void GoToNextPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment
                .MedicalOrdersRegisterPage);
            _registerMedicalAppointment.MedicalNotesItemButton.CompletedFormItemColors();
        }

        public string GetEvolutionSheetText()
        {
            return EvolutionSheetTextBox.FieldText;
        }

        public void AddManagementPlan(string managementPlanContent)
        {
            var managementPlan = new ManagementPlanDto
            {
                Description = managementPlanContent
            };
            _managementsPlans.Add(managementPlan);
        }

        public IList<ManagementPlanDto> GetManagementPlans()
        {
            return _managementsPlans;
        }
    }
}
