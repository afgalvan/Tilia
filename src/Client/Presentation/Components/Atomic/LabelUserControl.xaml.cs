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

        public new string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public new string FontSize
        {
            get => (string)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(string), typeof(LabelUserControl), new PropertyMetadata(null));
    }
}
