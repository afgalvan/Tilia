using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalNoteRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;
        private IList<string> ManagementsPlans { get; set; }

        public MedicalNoteRegisterPage(RegisterMedicalAppointmentUserControl registerMedicalAppointment)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            InitializeComponent();
            Loaded += OnLoadedPage;
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalNotesItemButton.CurrentFormItemColors();
        }

        private void GoBackToPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment.MedicalAppointmentPage);
            _registerMedicalAppointment.MedicalNotesItemButton.DefaultFormItemColors();
        }

        private void GoToNextPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment.MedicalOrdersRegisterPage);
            _registerMedicalAppointment.MedicalNotesItemButton.CompletedFormItemColors();
        }

        public void AddManagementPlan(string managementPlan) => ManagementsPlans.Add(managementPlan);
    }
}
