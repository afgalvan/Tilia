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
            get { return (string)GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }

        public string FontSize
        {
            get { return (string)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));
    }
}
