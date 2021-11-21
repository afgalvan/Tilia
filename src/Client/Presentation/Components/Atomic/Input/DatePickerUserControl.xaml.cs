using System;
using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic.Input
{
    public partial class DatePickerUserControl : UserControl
    {
        public DatePickerUserControl()
        {
            InitializeComponent();
            SetDefaultDatePicker();
        }

        private void SetDefaultDatePicker()
        {
            DatePickerWidth = "200";
            DatePickerFontSize = "15";
        }

        public string Text
        {
            get => DatePickerInput.Text;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                DatePickerInput.Text = Text;
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
            DependencyProperty.Register("DatePickerHint", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DatePickerWidthProperty =
            DependencyProperty.Register("DatePickerWidth", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DatePickerFontSizeProperty =
            DependencyProperty.Register("DatePickerFontSize", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));
    }
}
