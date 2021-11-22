using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Components.Atomic.Input
{
    public partial class NumericTextFieldUserControl : UserControl
    {
        public NumericTextFieldUserControl()
        {
            InitializeComponent();
        }

        private void TextField_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        public string Text
        {
            get => TextField.Text;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                TextField.Text = Text;
            }
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

        public static readonly DependencyProperty TextFieldFloatingHintProperty =
            DependencyProperty.Register("TextFieldFloatingHint", typeof(string), typeof(NumericTextFieldUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty TextFieldWidthProperty =
            DependencyProperty.Register("TextFieldWidth", typeof(string), typeof(NumericTextFieldUserControl), new PropertyMetadata("200"));

        public static readonly DependencyProperty TextFieldFontSizeProperty =
            DependencyProperty.Register("TextFieldFontSize", typeof(string), typeof(NumericTextFieldUserControl), new PropertyMetadata("15"));
    }
}
