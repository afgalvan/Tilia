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

        public string TextFieldFloatingHint
        {
            get => (string)GetValue(TextFieldFloatingHintProperty);
            set => SetValue(TextFieldFloatingHintProperty, value);
        }

        public new string TextFieldWidth
        {
            get => (string)GetValue(TextFieldWidthProperty);
            set => SetValue(TextFieldWidthProperty, value);
        }

        public new string TextFieldFontSize
        {
            get => (string)GetValue(TextFieldFontSizeProperty);
            set => SetValue(TextFieldFontSizeProperty, value);
        }

        private void SetDefaultTextField()
        {
            TextFieldWidth = "200";
            TextFieldFontSize = "16";
        }

        public static readonly DependencyProperty TextFieldFloatingHintProperty =
            DependencyProperty.Register("TextFieldFloatingHint", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TextFieldWidthProperty =
            DependencyProperty.Register("ButtonWidth", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TextFieldFontSizeProperty =
            DependencyProperty.Register("LabelFontSize", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));
    }
}
