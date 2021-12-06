using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Presentation.Windows;
using Requests.Appointments.MedicalNotes;

namespace Presentation.Components.Medical.MedicalForms
{
    public partial class MedicalOrdersRegisterPage : Page
    {
        private readonly RegisterMedicalAppointmentUserControl _registerMedicalAppointment;
        private readonly MainWindow                            _mainWindow;
        private readonly IList<DiagnosisDto>                   _diagnoses;
        private readonly IList<ReferralDto>                    _referrals;

        public MedicalOrdersRegisterPage(
            RegisterMedicalAppointmentUserControl registerMedicalAppointment,
            MainWindow mainWindow)
        {
            _registerMedicalAppointment = registerMedicalAppointment;
            _mainWindow                 = mainWindow;
            InitializeComponent();
            Loaded     += OnLoadedPage;
            _diagnoses =  new List<DiagnosisDto>();
            _referrals =  new List<ReferralDto>();
        }

        private void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalOrderItemButton.CurrentFormItemColors();
        }

        private void GoBackToPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.NavigateTo(_registerMedicalAppointment
                .MedicalNoteRegisterPage);
            _registerMedicalAppointment.MedicalOrderItemButton.DefaultFormItemColors();
        }

        private void FinishPageButton_OnClick(object sender, RoutedEventArgs e)
        {
            _registerMedicalAppointment.MedicalOrderItemButton.CompletedFormItemColors();
            _registerMedicalAppointment.FinishFormItemButton_OnClick(sender, e);
        }

        private void AddDiagnosis(string cie10ContentItem, string functionalDiagnosisContent)
        {
            var diganosis = new DiagnosisDto
            {
                CIE10      = cie10ContentItem,
                Functional = functionalDiagnosisContent
            };
            _diagnoses.Add(diganosis);
        }

        private void AddReferral(string referredDepartment, string referralDescription)
        {
            var referral = new ReferralDto
            {
                Department  = referredDepartment,
                Description = referralDescription
            };
            _referrals.Add(referral);
        }

        public IList<DiagnosisDto> GetDiagnoses()
        {
            return _diagnoses;
        }

        public IList<ReferralDto> GetReferrals()
        {
            return _referrals;
        }
    }
}
