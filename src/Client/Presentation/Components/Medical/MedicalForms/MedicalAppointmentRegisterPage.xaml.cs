using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Convert = Presentation.Utils.Convert;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalAppointmentRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;

        public MedicalAppointmentRegisterPage(
            RegisterMedicalAppointmentUserControl registerMedicalAppointment)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            InitializeComponent();
            Loaded += OnLoadedPage;
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalAppointmentItemButton.CurrentFormItemColors();
        }

        // BUTTON SECTION
        private void GoToNextPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment
                .MedicalNoteRegisterPage);
            _registerMedicalAppointment.MedicalAppointmentItemButton.CompletedFormItemColors();
        }

        // ATTRIBUTES SECTION
        public string GetPatientId() => PatientIdNumberTextBox.FieldText;

        public string GetDoctorId() => DoctorIdNumberTextBox.FieldText;

        public DateTime GetAppointmentDate()
        {
            return DateTime.Parse(AppointmentDatePicker.FieldText, CultureInfo.CurrentCulture);
        }

        public string GetAppointmentReason() => AppointmentReasonTextBox.FieldText;

        public string GetDiseaseHistory() => DiseaseHistoryTextBox.FieldText;

        public string GetAnamnesis() => AnamnesisTextBox.FieldText;
    }
}
