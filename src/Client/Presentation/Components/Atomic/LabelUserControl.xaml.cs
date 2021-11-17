using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic
{
    /// <summary>
    /// Lógica de interacción para LabelUserControl.xaml
    /// </summary>
    public partial class LabelUserControl : UserControl
    {
        public LabelUserControl()
        {
            InitializeComponent();
        }

        public string LabelContent
        {
            get => (string)GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }

        public string LabelFontSize
        {
            get => (string)GetValue(LabelFontSizeProperty);
            set => SetValue(LabelFontSizeProperty, value);
        }

        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty LabelFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));
    }
}
