using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Presentation.Services.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Presentation.Utils;
using Requests.Appointments;
using Requests.Dashboard;
using SkiaSharp;

namespace Presentation.Components.Dashboard
{
    /// <summary>
    /// Interaction logic for DashboardUserControl.xaml
    /// </summary>
    public partial class DashboardUserControl
    {
        private readonly DashboardService _dashboardService;

        public DashboardUserControl(DashboardService dashboardService)
        {
            InitializeComponent();
            _dashboardService         =  dashboardService;
            int limit = DateTime.Now.DayOfWeek.ToString().Length + 5;
            ScheduleCardLabel.Content =  DateTime.Now.ToLongDateString()[..limit];
            Loaded                    += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            DashboardInformationResponse response =
                await _dashboardService.GetStatistics(App.CancellationToken);
            LoadAttentions(response);
            LoadPatients(response.PatientsAmount);
            LoadAppointments(response.RecentAppointments);
        }

        private void LoadAppointments(
            IEnumerable<MedicalAppointmentResponse> recentAppointments)
        {
            recentAppointments.ToList()
                .ForEach(response =>
                    AppointmentsPanel.Children
                        .Add(AppointmentComponent(response))
                );
        }

        private Button AppointmentComponent(MedicalAppointmentResponse response)
        {
            var reasonText = new TextBlock { Text = response.AppointmentReason };
            var dateText = new TextBlock
            {
                Text       = $" {response.AppointmentDate.ToShortDateString()}",
                Foreground = ColorPalette.Gray
            };
            var panel = new StackPanel
            {
                Children    = { reasonText, dateText },
                Orientation = Orientation.Horizontal
            };

            return new Button
            {
                Content = panel,
                Cursor = Cursors.Hand,
                Background = Brushes.White,
                BorderThickness = new Thickness(0)
            };
        }

        private void LoadPatients(int patientsAmount)
        {
            PatientsAmountText.Text = $"{patientsAmount}";
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
    }
}
