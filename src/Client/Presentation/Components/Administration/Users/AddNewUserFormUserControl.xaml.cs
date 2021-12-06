using System;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using Presentation.Services;
using Presentation.Services.Http;
using Presentation.Utils;
using Presentation.Windows;

namespace Presentation.Components.Administration.Users
{
    public partial class AddNewUserFormUserControl
    {
        private readonly MainWindow _mainWindow;
        private readonly UsersService _usersService;
        private readonly EmployeesService _employeesService;

        public AddNewUserFormUserControl(MainWindow mainWindow, UsersService usersService,
            EmployeesService employeesService)
        {
            _mainWindow = mainWindow;
            _usersService = usersService;
            _employeesService = employeesService;
            InitializeComponent();
            RegisterProgressBarItem.CurrentFormItemColors();
            EmployeesComboBox.Loaded += PopulateEmployees;
        }

        private void GoBackButtonUserControl_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(
                new UsersPanelUserControl(_mainWindow, _usersService, _employeesService));
        }

        private async Task ShowMessageOnSuccess()
        {
            await _mainWindow.ShowMessageAsync("Exito", "Usuario creado correctamente");
        }

        private async Task ValidateEmail(string email)
        {
            if (!EmailValidator.EmailIsValid(email))
            {
                await _mainWindow.ShowMessageAsync("Error",
                    "Email inválido, porfavor rectifique");
            }
        }

        private async void FinishButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Ensure.AreAllFieldsCompleted(UsernameTextField.FieldText,
                EmailTextField.FieldText, PasswordTextField.GetPasswordValue()))
            {
                if (!Ensure.AreAllFieldsCompleted(EmployeesComboBox.FieldText))
                {
                    _ = await _mainWindow.ShowMessageAsync("Error al crear el usuario", "Asigne un empleado");
                    return;
                }
                await ValidateEmail(EmailTextField.FieldText);
                await CreateUser();
                return;
            }
            _ = await _mainWindow.ShowMessageAsync("Error al crear el usuario",
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
                _mainWindow.ChangeMainContentArea(
                    new UsersPanelUserControl(_mainWindow, _usersService, _employeesService));
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

        private async void PopulateEmployees(object sender, RoutedEventArgs e)
        {
            EmployeesComboBox.ComboBoxItemsSource = await _employeesService.GetAllEmployees(App.CancellationToken);
        }

    }
}
