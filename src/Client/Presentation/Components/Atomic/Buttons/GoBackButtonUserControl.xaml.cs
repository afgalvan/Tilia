using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic.Buttons
{
    public partial class GoBackButtonUserControl : UserControl
    {
        public event RoutedEventHandler Click;

        public GoBackButtonUserControl()
        {
            InitializeComponent();
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            Click?.Invoke(this, new RoutedEventArgs());
        }

        public string ButtonToolTip
        {
            get => (string)GetValue(ButtonToolTipProperty);
            set => SetValue(ButtonToolTipProperty, value);
        }

        public static readonly DependencyProperty ButtonToolTipProperty =
            DependencyProperty.Register("ButtonToolTip", typeof(string), typeof(GoBackButtonUserControl), new PropertyMetadata(null));
    }
}
