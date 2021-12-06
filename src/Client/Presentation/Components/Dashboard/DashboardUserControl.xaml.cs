using System;
using System.Collections.Generic;
using System.Linq;
using Presentation.Services.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LiveChartsCore.Defaults;
using LiveChartsCore.Measure;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Presentation.Components.Medical;
using Presentation.Utils;
using Presentation.Windows;
using Requests.Appointments;
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
            Loaded                    += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            DashboardInformationResponse response =
                await _dashboardService.GetStatistics(App.CancellationToken);
            LoadAttentions(response);
            LoadPatients(response.PatientsAmount);
            ActualDateText.Text = GetCurrentDate();
            LoadAppointments(response.RecentAppointments);
            LoadMappedAptitude(response.AptitudeCertificatesMap);
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

        private static Button AppointmentComponent(MedicalAppointmentResponse response)
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
                Content         = panel,
                Cursor          = Cursors.Hand,
                Background      = Brushes.White,
                BorderThickness = new Thickness(0)
            };
        }

        private void LoadPatients(int patientsAmount)
        {
            PatientsAmountText.Text = $"{patientsAmount}";
        }

        private static string GetCurrentDate()
        {
            return DateTime.Now.ToString("ddd dd MMM yyyy");
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

        private void LoadMappedAptitude(IDictionary<string, double> certificatesMap)
        {
            CertificatePieChart.Series = BuildCertificatesSeries(certificatesMap);
            CertificatePieChart.Total  = certificatesMap.Max(d => d.Value);
        }

        private static IEnumerable<PieSeries<ObservableValue>> BuildCertificatesSeries(
            IDictionary<string, double> certificateMap)
        {
            var builder = new GaugeBuilder
            {
                LabelFormatter = point => point.PrimaryValue + " " + point.Context.Series.Name,
                LabelsSize = 15,
                LabelsPosition = PolarLabelsPosition.Start,
                InnerRadius = 20,
                OffsetRadius = 8,
                BackgroundInnerRadius = 20
            };

            foreach ((string key, double value) in certificateMap)
            {
                builder.AddValue(new ObservableValue(value), key);
            }
            return builder.BuildSeries();
        }
    }
}
