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

        public string ToolTip
        {
            get { return (string)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }

        public string Content
        {
            get { return (string)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        public string Radius
        {
            get { return (string)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        public string Width
        {
            get { return (string)GetValue(WidthProperty); }
            set { SetValue(WidthProperty, value); }
        }

        public string Height
        {
            get { return (string)GetValue(HeightProperty); }
            set { SetValue(HeightProperty, value); }
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
