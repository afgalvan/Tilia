using System;
using System.Security.Authentication;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Services.Http;
using Presentation.Services.Http.Exceptions;
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
            if (Ensure.AreAllFieldsCompleted(UsernameField.Text,
                GetPasswordValue()))
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
                App.AccessToken = await RequestToken(UsernameField.Text, GetPasswordValue());
                //App.AccessToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI2NDIwZTQ5Ni0xNTdlLTRiZjMtYWQzZi00YTRmMDIzOWQ1N2IiLCJuYmYiOjE2Mzc4NzY4OTYsImV4cCI6MTYzODQ4MTY5NiwiaWF0IjoxNjM3ODc2ODk2fQ.4n59CFzStwai8W31KaXiLkD29sb1KD1RifkRwgCSrlY";
                OpenMainWindow();
            }
            catch (Exception e) when (e is AuthenticationException or ServerDownException)
            {
                await this.ShowMessageAsync("Error al iniciar sesión", e.Message);
            }
        }

        private async Task<string> RequestToken(string usernameOrEmail, string password)
        {
            return (await _authentication.SendLoginRequest(usernameOrEmail, password,
                App.CancellationToken)).Token;
        }

        private string GetPasswordValue()
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
