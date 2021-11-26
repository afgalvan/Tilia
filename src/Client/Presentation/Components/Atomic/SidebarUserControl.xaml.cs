using MaterialDesignThemes.Wpf;
using Presentation.Components.Administration;
using Presentation.Components.Dashboard;
using Presentation.Utils;
using Presentation.Windows;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Presentation.Components.Medical;
using Presentation.Components.Patients;
using Presentation.Services.Http;

namespace Presentation.Components.Atomic
{
    public partial class SidebarUserControl
    {
        private readonly MainWindow          _mainWindow;
        private readonly PatientsUserControl _patientsUserControl;

        public SidebarUserControl(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
            InitializeComponent();
            var api = _mainWindow.GetComponent<PatientService>();
            _patientsUserControl = new PatientsUserControl(_mainWindow, api);
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, DashboardTextBlock, DashboardIcon);
            _mainWindow.ChangeMainContentArea(new DashboardUserControl());
        }

        private void PatientsButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, PatientsTextBlock, PatientsIcon);
            _mainWindow.ChangeMainContentArea(_patientsUserControl);
        }

        private void MedicalMeetingButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, MedicalMeetingTextBlock, MedicalMeetingIcon);
            _mainWindow.ChangeMainContentArea(new MedicalAppointmentUserControl());
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, AdminTextBlock, AdminIcon);
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            ToggleButtonColor(sender, LogoutTextBlock, LogoutIcon);
            _mainWindow.LogoutSession();
        }

        private void ToggleButtonColor(object sender, TextBlock textBlock, Control icon)
        {
            ChangeToDefaultColor(ButtonStack);
            ChangeSelectedButtonColor((Button)sender, textBlock, icon);
        }

        private void ChangeToDefaultColor(Panel stackPanel)
        {
            SelectionUtil.RestorePanelButtonsBackground(stackPanel, Brushes.White);
            SelectionUtil.RestoreElementsForeground(GetToolBarIcons(), ColorPalette.Gray);
            SelectionUtil.RestoreElementsForeground(GetToolBarTextBlocks(), ColorPalette.Gray);
        }

        private IEnumerable<TextBlock> GetToolBarTextBlocks()
        {
            return new[]
            {
                DashboardTextBlock, PatientsTextBlock,
                AdminTextBlock,
                MedicalMeetingTextBlock,
                LogoutTextBlock
            };
        }

        private IEnumerable<PackIcon> GetToolBarIcons()
        {
            return new[]
            {
                DashboardIcon, PatientsIcon,
                MedicalMeetingIcon, AdminIcon,
                LogoutIcon
            };
        }

        private static void ChangeSelectedButtonColor(Control selectedButton,
            TextBlock textBlock, Control icon)
        {
            ShadowAssist.SetShadowDepth(selectedButton, ShadowDepth.Depth1);
            selectedButton.Background = ColorPalette.PrimaryColor;
            textBlock.Foreground      = Brushes.White;
            icon.Foreground           = Brushes.White;
        }
    }
}
