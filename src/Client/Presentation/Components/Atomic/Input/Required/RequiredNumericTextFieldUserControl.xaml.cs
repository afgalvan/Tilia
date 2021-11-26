using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Components.Atomic.Input.Required
{
    public partial class RequiredNumericTextFieldUserControl : UserControl
    {
        public RequiredNumericTextFieldUserControl()
        {
            InitializeComponent();
        }

        private void TextField_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public string FieldText
        {
            get => (string)GetValue(FieldTextHintProperty);
            set => SetValue(FieldTextHintProperty, value);
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

        public static readonly DependencyProperty FieldTextHintProperty =
            DependencyProperty.Register("FieldText", typeof(string), typeof(RequiredNumericTextFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty TextFieldFloatingHintProperty =
            DependencyProperty.Register("TextFieldFloatingHint", typeof(string),
                typeof(RequiredNumericTextFieldUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty TextFieldWidthProperty =
            DependencyProperty.Register("TextFieldWidth", typeof(string),
                typeof(RequiredNumericTextFieldUserControl), new PropertyMetadata("200"));

        public static readonly DependencyProperty TextFieldFontSizeProperty =
            DependencyProperty.Register("TextFieldFontSize", typeof(string),
                typeof(RequiredNumericTextFieldUserControl), new PropertyMetadata("15"));
    }
}
