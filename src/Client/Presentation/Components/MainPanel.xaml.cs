using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Presentation.Components.Dashboard;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Components.ClinicalHistories;
using Presentation.Components.MedAppointment;
using Presentation.Components.MedicalAppointment;
using Presentation.Utils;

namespace Presentation.Components
{
    public partial class MainPanel
    {
        private readonly SelectionUtil _selectionUtil;
        private readonly ContentAreaUtil _contentAreaUtil;

        public MainPanel(SelectionUtil selectionUtil, ContentAreaUtil contentAreaUtil)
        {
            _selectionUtil = selectionUtil;
            _contentAreaUtil = contentAreaUtil;
            InitializeComponent();
            _contentAreaUtil.DisplayContentInArea(MainPanelContentArea, new DashboardUserControl());
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, DashboardTextBlock, DashboardIcon);
            _contentAreaUtil.DisplayContentInArea(MainPanelContentArea, new DashboardUserControl());
        }

        private void MedicalAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalAppointmentTextBlock, MedicalAppointmentIcon);
            _contentAreaUtil.DisplayContentInArea(MainPanelContentArea, new DefaultMedAppointmentPanelUserControl());
        }

        private void ClinicalHistoriesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ClinicalHistoriesTextBlock, ClinicalHistoriesIcon);
            _contentAreaUtil.DisplayContentInArea(MainPanelContentArea, new ClinicalHistoryDataUserControl());
        }

        private async void MedicalNotesButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalNotesTextBlock, MedicalNotesIcon);
            await this.ShowMessageAsync("Tilia", "MedicalNotes");
        }

        private async void UsersButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, UsersTextBlock, UsersIcon);
            await this.ShowMessageAsync("Tilia", "Users");
        }

        private async void ConfigButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, ConfigTextBlock, ConfigIcon);
            await this.ShowMessageAsync("Tilia", "Configuration");
        }

        private async void MedicalOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalOrdersTextBlock, MedicalOrdersIcon);
            await this.ShowMessageAsync("Tilia", "MedicalOrders");
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, LogoutTextBlock, LogoutIcon);
            await this.ShowMessageAsync("Tilia", "Logout");
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
