using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;

namespace Presentation.Components.Medical
{
    public partial class MedicalAppointmentMainPanelUserControl : UserControl
    {
        private readonly AppointmentsService _appointmentsService;

        public MedicalAppointmentMainPanelUserControl(AppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
            InitializeComponent();
            AppointmentsDataGrid.Loaded += LoadTableInformation;
        }

        private async void LoadTableInformation(object sender, RoutedEventArgs e)
        {
            AppointmentsDataGrid.ItemsSource =
                await _appointmentsService.GetAppointments(App.CancellationToken);
        }
    }
}
