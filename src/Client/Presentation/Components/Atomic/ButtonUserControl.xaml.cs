using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic
{
    /// <summary>
    /// Lógica de interacción para ButtonUserControl.xaml
    /// </summary>
    public partial class ButtonUserControl : UserControl
    {
        public ButtonUserControl()
        {
            InitializeComponent();
            DefaultButtonType();
        }

        public new string ToolTip
        {
            get => (string)GetValue(ToolTipProperty);
            set => SetValue(ToolTipProperty, value);
        }

        public new string Content
        {
            get => (string)GetValue(ContentProperty);
            set => SetValue(ContentProperty, value);
        }

        public string Radius
        {
            get => (string)GetValue(RadiusProperty);
            set => SetValue(RadiusProperty, value);
        }

        public new string Width
        {
            get => (string)GetValue(WidthProperty);
            set => SetValue(WidthProperty, value);
        }

        public new string Height
        {
            get => (string)GetValue(HeightProperty);
            set => SetValue(HeightProperty, value);
        }

        public void DefaultButtonType()
        {
            Radius = "20";
            Width = "120";
            Height = "35";
        }

        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register("ToolTip", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty RadiusProperty =
            DependencyProperty.Register("Radius", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty WidthProperty =
            DependencyProperty.Register("Width", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty HeightProperty =
            DependencyProperty.Register("Height", typeof(string), typeof(ButtonUserControl), new PropertyMetadata(null));
    }
}
