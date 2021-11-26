using System.Windows;
using System.Windows.Controls;

namespace Presentation.Components.Atomic.Input.Required
{
    public partial class RequiredPasswordFieldUserControl : UserControl
    {
        public RequiredPasswordFieldUserControl()
        {
            InitializeComponent();
        }

        public string GetPasswordValue()
        {
            return PasswordField.IsVisible
                ? PasswordField.Password
                : UnmaskedPasswordField.Text;
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UnmaskedPasswordField.Text = PasswordField.Password;
            PasswordField.Visibility = Visibility.Collapsed;
            UnmaskedPasswordField.Visibility = Visibility.Visible;
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordField.Password = UnmaskedPasswordField.Text;
            UnmaskedPasswordField.Visibility = Visibility.Collapsed;
            PasswordField.Visibility = Visibility.Visible;
        }

        public string PasswordInput
        {
            get => (string)GetValue(PasswordInputProperty);
            set => SetValue(PasswordInputProperty, value);
        }

        public string PasswordBoxFloatingHint
        {
            get => (string)GetValue(PasswordBoxFloatingHintProperty);
            set => SetValue(PasswordBoxFloatingHintProperty, value);
        }

        public string PasswordBoxWidth
        {
            get => (string)GetValue(PasswordBoxWidthProperty);
            set => SetValue(PasswordBoxWidthProperty, value);
        }

        public string PasswordBoxFontSize
        {
            get => (string)GetValue(PasswordBoxFontSizeProperty);
            set => SetValue(PasswordBoxFontSizeProperty, value);
        }


        public static readonly DependencyProperty PasswordInputProperty =
            DependencyProperty.Register("PasswordInput", typeof(string), typeof(RequiredPasswordFieldUserControl), new PropertyMetadata(null));

        public static readonly DependencyProperty PasswordBoxFloatingHintProperty =
            DependencyProperty.Register("PasswordBoxFloatingHint", typeof(string), typeof(RequiredPasswordFieldUserControl), new PropertyMetadata(""));

        public static readonly DependencyProperty PasswordBoxWidthProperty =
            DependencyProperty.Register("PasswordBoxWidth", typeof(string), typeof(RequiredPasswordFieldUserControl), new PropertyMetadata("200"));

        public static readonly DependencyProperty PasswordBoxFontSizeProperty =
            DependencyProperty.Register("PasswordBoxFontSize", typeof(string), typeof(RequiredPasswordFieldUserControl), new PropertyMetadata("15"));
    }
}
