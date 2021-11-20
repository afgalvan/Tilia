using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic.Input
{
    public partial class TextFieldUserControl : UserControl
    {
        public TextFieldUserControl()
        {
            InitializeComponent();
            SetDefaultTextField();
        }

        public string TextFieldFloatingHint
        {
            get => (string)GetValue(TextFieldFloatingHintProperty);
            set => SetValue(TextFieldFloatingHintProperty, value);
        }

        public string TextFieldWidth
        {
            get => (string)GetValue(TextFieldWidthProperty);
            set => SetValue(TextFieldWidthProperty, value);
        }

        public string TextFieldFontSize
        {
            get => (string)GetValue(TextFieldFontSizeProperty);
            set => SetValue(TextFieldFontSizeProperty, value);
        }

        public string Text
        {
            get => TextField.Text;
            set => TextField.Text = Text;
        }

        private void SetDefaultTextField()
        {
            TextFieldWidth = "200";
            TextFieldFontSize = "16";
        }

        public static readonly DependencyProperty TextFieldFloatingHintProperty =
            DependencyProperty.Register("TextFieldFloatingHint", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TextFieldWidthProperty =
            DependencyProperty.Register("TextFieldWidth", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TextFieldFontSizeProperty =
            DependencyProperty.Register("TextFieldFontSize", typeof(string), typeof(TextFieldUserControl), new PropertyMetadata(null));
    }
}
