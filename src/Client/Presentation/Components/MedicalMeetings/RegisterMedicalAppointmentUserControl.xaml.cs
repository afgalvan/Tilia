using Presentation.Windows;

namespace Presentation.Components.MedicalMeetings
{
    /// <summary>
    /// Interaction logic for RegisterMedicalAppointmentUserControl.xaml
    /// </summary>
    public partial class RegisterMedicalAppointmentUserControl
    {
        private readonly MainWindow _mainWindowControl;

        public RegisterMedicalAppointmentUserControl(MainWindow mainWindow)
        {
            _mainWindowControl = mainWindow;
            InitializeComponent();
        }

        private void BackToQueryAppointmentUserControlButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _mainWindowControl.ChangeMainContentArea(new QueryMedicalAppointmentUserControl(_mainWindowControl));
        }
    }
}
