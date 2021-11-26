using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Services.Http;
using Presentation.Utils;
using Presentation.Windows;

namespace Presentation.Components.Administration.Users
{
    public partial class AddNewUserFormUserControl
    {
        private readonly MainWindow   _mainWindow;
        private readonly UsersService _usersService;

        public AddNewUserFormUserControl(MainWindow mainWindow, UsersService usersService)
        {
            _mainWindow   = mainWindow;
            _usersService = usersService;
            InitializeComponent();
            RegisterProgressBarItem.CurrentFormItemColors();
        }

        private async Task ShowMessageOnSuccess()
        {
            await _mainWindow.ShowMessageAsync("Exito", "Usuario creado correctamente");
        }

        private async void FinishButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Ensure.AreAllFieldsCompleted(UsernameTextField.FieldText,
                EmailTextField.FieldText, PasswordTextField.GetPasswordValue()))
            {
                await CreateUser();
                return;
            }

            await _mainWindow.ShowMessageAsync("Error al crear el usuario",
                "Llene los campos vacios");
        }

        private async Task CreateUser()
        {
            try
            {
                await _usersService.CreateUser(UsernameTextField.FieldText,
                    EmailTextField.FieldText, PasswordTextField.GetPasswordValue(),
                    App.CancellationToken);
                ChangeColorsOnComplete();
                await ShowMessageOnSuccess();
                _mainWindow.ChangeMainContentArea(new UsersPanelUserControl(_mainWindow, _usersService));
            }
            catch (Exception e)
            {
                await _mainWindow.ShowMessageAsync("Error al crear el usuario", e.Message);
            }
        }

        private void ChangeColorsOnComplete()
        {
            RegisterProgressBarItem.CompletedFormItemColors();
            FinishRegisterProgressBarItem.CompletedFormItemColors();
        }
    }
}
