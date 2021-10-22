using MahApps.Metro.Controls;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using Presentation.Components.Dashboard;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;

namespace Presentation.Components
{

    public partial class MainPanel : MetroWindow
    {
        public MainPanel()
        {
            InitializeComponent();
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, DashboardTextBlock, DashboardIcon);
            ContentArea.Content = new DashboardUserControl();
        }

        private void MedicalAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalAppointmentTextBlock, MedicalAppointmentIcon);
        }

        private void ToggleButtonColor(object sender, TextBlock textBlock, PackIcon icon)
        {
            ChangeToDefaultColor();
            var selectedButton = (Button)sender;
            selectedButton.Background = (Brush)new BrushConverter().ConvertFrom("#FF6AB9B4");
            textBlock.Foreground = Brushes.White;
            icon.Foreground = Brushes.White;
        }

        private void ChangeToDefaultColor()
        {
            ButtonStack.Children.OfType<Button>()
                .ToList().ForEach(button => button.Background = Brushes.White);

            IEnumerable<TextBlock> textBlocks = new[] { DashboardTextBlock, MedicalAppointmentTextBlock };
            IEnumerable<PackIcon> icons = new[] { DashboardIcon, MedicalAppointmentIcon };

            var defaultColor = (Brush)new BrushConverter().ConvertFrom("#FFA3AED0");
            _ = textBlocks.Zip(icons, (t, i) => i.Foreground = t.Foreground = defaultColor)
                .ToList();
        }
    }
}
