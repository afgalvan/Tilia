using System.Windows;
using System.Windows.Controls;
using Presentation.Services;
using Presentation.Windows;

namespace Presentation.Components.Administration.Employees
{
    public partial class EmployeesUserControl : UserControl
    {
        private readonly EmployeesService _employeesService;
        private readonly MainWindow _mainWindow;

        public EmployeesUserControl(MainWindow mainWindow, EmployeesService employeesService)
        {
            _employeesService = employeesService;
            _mainWindow = mainWindow;
            InitializeComponent();
            EmployeesDataGrid.Loaded += LoadEmployeesInformation;
        }

        private async void LoadEmployeesInformation(object sender, RoutedEventArgs e)
        {
            EmployeesDataGrid.ItemsSource = await _employeesService.GetAllEmployees(App.CancellationToken);
        }

        private void GoBackButtonUserControl_OnClick(object sender, RoutedEventArgs e)
        {
            _mainWindow.ChangeMainContentArea(new AdministrationUserControl(_mainWindow));
        }
    }
}
