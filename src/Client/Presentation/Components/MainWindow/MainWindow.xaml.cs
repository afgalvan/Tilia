using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using MaterialDesignThemes.Wpf;
using Presentation.Utils;

namespace Presentation.Components.MainWindow
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly SelectionUtil _selectionUtil;

        public MainWindow(SelectionUtil selectionUtil)
        {
            _selectionUtil = selectionUtil;
            InitializeComponent();
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
            textBlock.Foreground = Brushes.White;
            icon.Foreground = Brushes.White;
        }
    }
}

