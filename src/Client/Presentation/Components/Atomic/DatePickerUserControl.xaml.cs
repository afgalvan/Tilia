using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic
{
    /// <summary>
    /// Lógica de interacción para DatePickerUserControl.xaml
    /// </summary>
    public partial class DatePickerUserControl : UserControl
    {
        public DatePickerUserControl()
        {
            InitializeComponent();
            SetDefaultDatePicker();
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

        private void SetDefaultDatePicker()
        {
            DatePickerWidth = "200";
            DatePickerFontSize = "16";
        }

        public static readonly DependencyProperty DatePickerHintProperty =
            DependencyProperty.Register("DatePickerHint", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DatePickerWidthProperty =
            DependencyProperty.Register("DatePickerWidth", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DatePickerFontSizeProperty =
            DependencyProperty.Register("DatePickerFontSize", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));
    }
}
