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
            ContentArea.Content = new DashboardUserControl();
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

        private void ClinicalHistoriesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ClinicalHistoriesTextBlock, ClinicalHistoriesIcon);
        }

        private void MedicalNotesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalNotesTextBlock, MedicalNotesIcon);
        }

        private void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, UsersTextBlock, UsersIcon);
        }

        private void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ConfigTextBlock, ConfigIcon);
        }

        private void MedicalOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalOrdersTextBlock, MedicalOrdersIcon);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, LogoutTextBlock, LogoutIcon);
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

            IEnumerable<TextBlock> textBlocks = new[] { DashboardTextBlock, MedicalAppointmentTextBlock,
                ClinicalHistoriesTextBlock, MedicalNotesTextBlock, UsersTextBlock, ConfigTextBlock,
                MedicalOrdersTextBlock, LogoutTextBlock };
            IEnumerable<PackIcon> icons = new[] { DashboardIcon, MedicalAppointmentIcon,
                ClinicalHistoriesIcon, MedicalNotesIcon, UsersIcon, ConfigIcon, MedicalOrdersIcon, LogoutIcon
            };

            var defaultColor = (Brush)new BrushConverter().ConvertFrom("#FFA3AED0");
            _ = textBlocks.Zip(icons, (t, i) => i.Foreground = t.Foreground = defaultColor)
                .ToList();
        }
    }
}
