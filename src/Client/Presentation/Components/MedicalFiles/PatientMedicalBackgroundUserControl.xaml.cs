using System.Windows;
using Presentation.Components.MedicalFiles.Patients;

namespace Presentation.Components.MedicalFiles
{
    /// <summary>
    /// Logic interaction for PatientMedicalBackgroundUserControl.xaml
    /// </summary>
    public partial class PatientMedicalBackgroundUserControl
    {
        public PatientMedicalBackgroundUserControl()
        {
            InitializeComponent();
            DataRegisterContentArea.Content = new PatientBasicDataRegisterUserControl();
        }

        private void BasicDataButton_Click(object sender, RoutedEventArgs e)
        {
        }

    }
}
