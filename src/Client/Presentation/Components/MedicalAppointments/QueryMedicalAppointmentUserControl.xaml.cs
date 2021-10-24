using System.Windows;
using System.Windows.Controls;
using Presentation.Windows;

namespace Presentation.Components.MedAppointment
{
    /// <summary>
    /// Interaction logic for QueryMedicalAppointmentUserControl.xaml
    /// </summary>
    public partial class QueryMedicalAppointmentUserControl : UserControl
    {
        private readonly MainWindow _mainWindowControl;

        public QueryMedicalAppointmentUserControl(MainWindow mainWindow)
        {
            _mainWindowControl = mainWindow;
            InitializeComponent();
        }

        private void AddAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            _mainWindowControl.ChangeMainContentArea(new RegisterMedicalAppointmentUserControl());
        }
    }
}
