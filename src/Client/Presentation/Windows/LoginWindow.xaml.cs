using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Services.Http;
using Presentation.Utils;

namespace Presentation.Windows
{
    public partial class LoginWindow
    {
        private readonly MainWindow            _mainWindow;
        private readonly AuthenticationService _authentication;

        public LoginWindow(MainWindow mainWindow, AuthenticationService authentication)
        {
            InitializeComponent();
            _mainWindow     = mainWindow;
            _authentication = authentication;
        }

        private async void LogInButton_Click(object sender, EventArgs e)
        {
            if (ValidationControl.AreAllFieldsCompleted(UsernameField.Text,
                GetPasswordField()))
            {
                await LoginUser();
                return;
            }

            await this.ShowMessageAsync("Error al iniciar sesión", "Ingrese todos los datos");
        }

        private async Task LoginUser()
        {
            try
            {
                /*await _authentication.SendLoginRequest(UsernameField.Text, GetPasswordField(),
                    App.CancellationToken);*/
                OpenMainWindow();
            }
            catch (AuthenticationException a)
            {
                await this.ShowMessageAsync("Error al iniciar sesión", a.Message);
            }
        }

        private string GetPasswordField()
        {
            return PasswordField.IsVisible
                ? PasswordField.Password
                : UnmaskedPasswordField.Text;
        }

        private void OpenMainWindow()
        {
            _mainWindow.Show();
            Hide();
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
