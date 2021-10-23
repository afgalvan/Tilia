using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Presentation.Components.Dashboard;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using Presentation.Components.ClinicalHistories;
using Presentation.Components.MedicalAppointment;
using Presentation.Utils;

namespace Presentation.Components
{
    public partial class MainPanel
    {
        private readonly SelectionUtil _selectionUtil;

        public MainPanel(SelectionUtil selectionUtil)
        {
            _selectionUtil = selectionUtil;
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
            ContentArea.Content = new MedicalAppointmentUserControl();
        }

        private void ClinicalHistoriesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ClinicalHistoriesTextBlock, ClinicalHistoriesIcon);
            ContentArea.Content = new ClinicalHistoryDataUserControl();
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

        private void ToggleButtonColor(object sender, TextBlock textBlock, Control icon)
        {
            ChangeToDefaultColor(ButtonStack);
            ChangeSelectedButtonColor((Button)sender, textBlock, icon);
        }

        private void ChangeToDefaultColor(Panel stackPanel)
        {
            _selectionUtil.RestorePanelButtonsBackground(stackPanel, Brushes.White);
            _selectionUtil.RestoreElementsForeground(GetToolBarIcons(), "#FFA3AED0");
            _selectionUtil.RestoreElementsForeground(GetToolBarTextBlocks(), "#FFA3AED0");
        }

        private IEnumerable<TextBlock> GetToolBarTextBlocks()
        {
            return new[]
            {
                DashboardTextBlock, MedicalAppointmentTextBlock,
                ClinicalHistoriesTextBlock, MedicalNotesTextBlock, UsersTextBlock,
                ConfigTextBlock,
                MedicalOrdersTextBlock, LogoutTextBlock
            };
        }

        private IEnumerable<PackIcon> GetToolBarIcons()
        {
            return new[]
            {
                DashboardIcon, MedicalAppointmentIcon,
                ClinicalHistoriesIcon, MedicalNotesIcon, UsersIcon, ConfigIcon,
                MedicalOrdersIcon, LogoutIcon
            };
        }

        private static void ChangeSelectedButtonColor(Control selectedButton,
            TextBlock textBlock, Control icon)
        {
            selectedButton.Background = (Brush)new BrushConverter().ConvertFrom("#FF6AB9B4");
            textBlock.Foreground      = Brushes.White;
            icon.Foreground           = Brushes.White;
        }
    }
}
