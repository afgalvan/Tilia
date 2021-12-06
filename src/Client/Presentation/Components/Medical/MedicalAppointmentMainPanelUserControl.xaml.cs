using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Medical
{
    public partial class MedicalAppointmentMainPanelUserControl : UserControl
    {
        private readonly AppointmentsService _appointmentsService;
        private readonly MainWindow          _mainWindow;

        public MedicalAppointmentMainPanelUserControl(AppointmentsService appointmentsService,
            MainWindow mainWindow)
        {
            _appointmentsService = appointmentsService;
            _mainWindow          = mainWindow;
            InitializeComponent();
            AppointmentsDataGrid.Loaded += LoadTableInformation;
        }

        private async void LoadTableInformation(object sender, RoutedEventArgs e)
        {
            AppointmentsDataGrid.ItemsSource =
                await _appointmentsService.GetAppointments(App.CancellationToken);
        }

        private void AddAppointmentButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(
                new RegisterMedicalAppointmentUserControl(_mainWindow, _appointmentsService));
        }
    }
}
