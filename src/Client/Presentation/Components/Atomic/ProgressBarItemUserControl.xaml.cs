using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation.Components.Atomic
{
    public partial class ProgressBarItemUserControl : UserControl
    {
        private readonly BrushConverter _brushConverter;

        public ProgressBarItemUserControl()
        {
            InitializeComponent();
            _brushConverter = new BrushConverter();
        }

        public void CurrentFormItemColors()
        {
            ProgressBarItemIcon = "CircleEditOutline";
            var actualColor = (Brush)_brushConverter.ConvertFrom("#20abfc");
            Icon.Foreground = actualColor;
            TextBlockInput.Foreground = actualColor;
        }

        public void CompletedFormItemColors()
        {
            ProgressBarItemIcon = "CheckboxMarkedCircleOutline";
            var actualColor = (Brush)_brushConverter.ConvertFrom("#6ab9b4");
            Icon.Foreground = actualColor;
            TextBlockInput.Foreground = actualColor;
        }

        public string ProgressBarItemIcon
        {
            get => (string)GetValue(ProgressBarItemIconProperty);
            set => SetValue(ProgressBarItemIconProperty, value);
        }

        public string ProgressBarItemText
        {
            get => (string)GetValue(ProgressBarItemTextProperty);
            set => SetValue(ProgressBarItemTextProperty, value);
        }

        public string ProgressBarItemsForeground
        {
            get => (string)GetValue(ProgressBarItemsForegroundProperty);
            set => SetValue(ProgressBarItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ProgressBarItemTextProperty =
            DependencyProperty.Register("ProgressBarItemText", typeof(string), typeof(ProgressBarItemUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty ProgressBarItemIconProperty =
            DependencyProperty.Register("ProgressBarItemIcon", typeof(string), typeof(ProgressBarItemUserControl), new PropertyMetadata("CheckboxBlankCircleOutline"));

        public static readonly DependencyProperty ProgressBarItemsForegroundProperty =
            DependencyProperty.Register("ProgressBarItemsForeground", typeof(string), typeof(ProgressBarItemUserControl), new PropertyMetadata("Gray"));

    }
}
