using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic
{
    /// <summary>
    /// Lógica de interacción para TextFieldUserControl.xaml
    /// </summary>
    public partial class TextFieldUserControl : UserControl
    {
        public TextFieldUserControl()
        {
            InitializeComponent();
            DefaultTextField();
        }

        public string FloatingHint
        {
            get { return (string)GetValue(FloatingHintProperty); }
            set { SetValue(FloatingHintProperty, value); }
        }

        public string Width
        {
            get { return (string)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public string FontSize
        {
            get { return (string)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        private void DefaultTextField()
        {
            Width = "200";
            FontSize = "16";
        }

        public static readonly DependencyProperty FloatingHintProperty =
            DependencyProperty.Register("FloatingHint", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register("FontSize", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));
    }
}
