using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Presentation.Components.Atomic.Buttons
{
    public partial class ProgressBarButtonUserControl : UserControl
    {
        public event RoutedEventHandler Click;
        private readonly BrushConverter _brushConverter;

        public ProgressBarButtonUserControl()
        {
            InitializeComponent();
            _brushConverter = new BrushConverter();
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, new RoutedEventArgs());
        }

        public void DefaultFormItemColors()
        {
            ButtonIconName = "CheckboxBlankCircleOutline";
            var actualColor = new SolidColorBrush(Colors.Gray);
            ButtonIcon.Foreground = actualColor;
            ButtonText.Foreground = actualColor;
        }

        public void CurrentFormItemColors()
        {
            ButtonIconName = "CircleEditOutline";
            var actualColor = (Brush)_brushConverter.ConvertFrom("#20abfc");
            ButtonIcon.Foreground = actualColor;
            ButtonText.Foreground = actualColor;
        }

        public void CompletedFormItemColors()
        {
            ButtonIconName = "CheckboxMarkedCircleOutline";
            var actualColor = (Brush)_brushConverter.ConvertFrom("#6ab9b4");
            ButtonIcon.Foreground = actualColor;
            ButtonText.Foreground = actualColor;
        }


        public string ButtonToolTip
        {
            get => (string)GetValue(ButtonToolTipProperty);
            set => SetValue(ButtonToolTipProperty, value);
        }

        public string ButtonContent
        {
            get => (string)GetValue(ButtonContentProperty);
            set => SetValue(ButtonContentProperty, value);
        }

        public string ButtonIconName
        {
            get => (string)GetValue(ButtonIconProperty);
            set => SetValue(ButtonIconProperty, value);
        }

        public string ButtonWidth
        {
            get => (string)GetValue(ButtonWidthProperty);
            set => SetValue(ButtonWidthProperty, value);
        }

        public string ButtonHeight
        {
            get => (string)GetValue(ButtonHeightProperty);
            set => SetValue(ButtonHeightProperty, value);
        }

        public string ButtonRadius
        {
            get => (string)GetValue(ButtonRadiusProperty);
            set => SetValue(ButtonRadiusProperty, value);
        }

        public string ButtonIsEnabled
        {
            get => (string)GetValue(ButtonIsEnabledProperty);
            set => SetValue(ButtonIsEnabledProperty, value);
        }

        public string ButtonItemsForeground
        {
            get => (string)GetValue(ButtonItemsForegroundProperty);
            set => SetValue(ButtonItemsForegroundProperty, value);
        }

        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ButtonIconProperty =
            DependencyProperty.Register("ButtonIconName", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata("CheckboxBlankCircleOutline"));

        public static readonly DependencyProperty ButtonToolTipProperty =
            DependencyProperty.Register("ButtonToolTip", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ButtonWidthProperty =
            DependencyProperty.Register("ButtonWidth", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata("130"));

        public static readonly DependencyProperty ButtonHeightProperty =
            DependencyProperty.Register("ButtonHeight", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata("35"));

        public static readonly DependencyProperty ButtonRadiusProperty =
            DependencyProperty.Register("ButtonRadius", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ButtonIsEnabledProperty =
            DependencyProperty.Register("ButtonIsEnabled", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ButtonItemsForegroundProperty =
            DependencyProperty.Register("ButtonItemsForeground", typeof(string), typeof(ProgressBarButtonUserControl), new PropertyMetadata("Gray"));
    }
}

