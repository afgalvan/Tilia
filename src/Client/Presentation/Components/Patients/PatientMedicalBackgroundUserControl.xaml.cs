using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Patients
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
            ChangeDataRegisterContentArea(new PatientBasicDataRegisterUserControl());
        }

        private void ContactInfoButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDataRegisterContentArea(new PatientContactDataRegisterUserControl());
        }

        private void MedicalInfoButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeDataRegisterContentArea(new PatientMedicalDataRegisterUserControl());
        }

        public void ChangeDataRegisterContentArea(UserControl content)
        {
            if (content == null)
            {
                DataRegisterContentArea.Content = new PatientBasicDataRegisterUserControl();
                return;
            }
            if (content.GetType() == DataRegisterContentArea.Content.GetType())
            {
                return;
            }

            DataRegisterContentArea.Content = content;
        }
    }
}
