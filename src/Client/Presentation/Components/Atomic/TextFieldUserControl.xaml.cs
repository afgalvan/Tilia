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
        }

        public string FloatingHint
        {
            get { return (string)GetValue(FloatingHintProperty); }
            set { SetValue(FloatingHintProperty, value); }
        }

        public static readonly DependencyProperty FloatingHintProperty =
            DependencyProperty.Register("FloatingHint", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));
    }
}
