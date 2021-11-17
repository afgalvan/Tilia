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
        }

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register("Hint", typeof(string), typeof(DatePickerUserControl), new PropertyMetadata(null));
    }
}
