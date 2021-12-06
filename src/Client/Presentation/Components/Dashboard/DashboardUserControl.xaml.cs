using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Presentation.Services.Http;
using System.Windows;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Presentation.Components.Atomic;
using Presentation.Components.Medical;
using Presentation.Windows;
using Requests.Dashboard;
using SkiaSharp;

namespace Presentation.Components.Dashboard
{
    public partial class DashboardUserControl
    {
        private readonly DashboardService _dashboardService;
        private readonly MainWindow _mainWindow;
        private readonly MedicalAppointmentMainPanelUserControl _appointmentMainPanel;

        public DashboardUserControl(DashboardService dashboardService, MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<AppointmentsService>();
            _appointmentMainPanel =
                new MedicalAppointmentMainPanelUserControl(api, _mainWindow);
            _dashboardService =  dashboardService;
            Loaded            += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            DashboardInformationResponse response =
                await _dashboardService.GetStatistics(App.CancellationToken);
            LoadAttentions(response);
            LoadPatients(response.PatientsAmount);
            ActualDateText.Text = GetActualDate();
        }

        private void LoadPatients(int patientsAmount)
        {
            PatientsAmountText.Text = $"{patientsAmount}";
        }

        private string GetActualDate()
        {
            return DateTime.Now.ToString("ddd, dd MMM yyyy");
        }

        private void LoadAttentions(DashboardInformationResponse response)
        {
            var line = new LineSeries<double>
            {
                Values         = response.AttentionHistoric.Select(d => (double)d),
                Fill           = null,
                LineSmoothness = 0.5,
                Stroke         = new SolidColorPaint(SKColor.Parse("#FF6AB9B4"), 4),
                GeometrySize   = 10,
                GeometryStroke = new SolidColorPaint(SKColor.Parse("#FF6AB9B4"), 4),
                Name           = "Atención de historias"
            };
            AttentionsHistoryChart.Series = new[] { line };
        }

        private void ScheduleCardButton_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(_appointmentMainPanel);
        }
    }
}
