using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Windows
{
    public partial class LoginWindow
    {
        private readonly IServiceProvider _serviceProvider;

        public LoginWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            new MainWindow(_serviceProvider).Show();
            Close();
        }

        private void ShowPasswordCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UnmaskedPasswordField.Text       = PasswordField.Password;
            PasswordField.Visibility         = Visibility.Collapsed;
            UnmaskedPasswordField.Visibility = Visibility.Visible;
        }

        private void ShowPasswordCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordField.Password           = UnmaskedPasswordField.Text;
            UnmaskedPasswordField.Visibility = Visibility.Collapsed;
            PasswordField.Visibility         = Visibility.Visible;
        }
    }
}
