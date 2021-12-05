using System.Linq;
using Presentation.Services.Http;
using System.Windows;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Presentation.Utils;
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
            _dashboardService =  dashboardService;
            Loaded            += OnLoaded;
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            DashboardInformationResponse response =
                await _dashboardService.GetStatistics(App.CancellationToken);
            var line = new LineSeries<double>
            {
                Values         = response.AttentionHistoric.Select(d => (double)d),
                Fill           = null,
                LineSmoothness = 1,
                Stroke         = new SolidColorPaint(SKColor.Parse("#FF6AB9B4"), 4),
                GeometrySize   = 10,
                GeometryStroke = new SolidColorPaint(SKColor.Parse("#FF6AB9B4"), 4),
                Name           = "Atención de historias"
            };
            AttentionsHistoryChart.Series = new[] { line };
        }
    }
}
