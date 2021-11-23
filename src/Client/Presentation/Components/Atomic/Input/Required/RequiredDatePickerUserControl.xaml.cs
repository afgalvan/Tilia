using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Presentation.Components.Atomic.Input.Required
{
    public partial class RequiredDatePickerUserControl : UserControl
    {
        public RequiredDatePickerUserControl()
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
            get => RequiredDatePickerInput.Text;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                RequiredDatePickerInput.Text = Text;
            }
        }

        public string DatePickerHint
        {
            get => (string)GetValue(DatePickerHintProperty);
            set => SetValue(DatePickerHintProperty, value);
        }

        public string DatePickerWidth
        {
            get => (string)GetValue(DatePickerWidthProperty);
            set => SetValue(DatePickerWidthProperty, value);
        }

        public string DatePickerFontSize
        {
            get => (string)GetValue(DatePickerFontSizeProperty);
            set => SetValue(DatePickerFontSizeProperty, value);
        }

        public static readonly DependencyProperty DatePickerHintProperty =
            DependencyProperty.Register("DatePickerHint", typeof(string), typeof(RequiredDatePickerUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty DatePickerWidthProperty =
            DependencyProperty.Register("DatePickerWidth", typeof(string), typeof(RequiredDatePickerUserControl), new PropertyMetadata("200"));

        public static readonly DependencyProperty DatePickerFontSizeProperty =
            DependencyProperty.Register("DatePickerFontSize", typeof(string), typeof(RequiredDatePickerUserControl), new PropertyMetadata("15"));
    }
}

