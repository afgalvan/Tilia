using System.Windows;
using System.Windows.Controls;
using Presentation.Services.Http;
using Presentation.Windows;

namespace Presentation.Components.Administration.Roles
{
    public partial class RolesPanelUserControl : UserControl
    {
        private readonly RolesService _rolesService;
        private readonly MainWindow _mainWindow;

        public RolesPanelUserControl(MainWindow mainWindow, RolesService rolesService)
        {
            _rolesService = rolesService;
            _mainWindow = mainWindow;
            InitializeComponent();
            SaniryRoleDataGrid.Loaded += LoadSanitaryRolesInformation;
        }

        private async void LoadSanitaryRolesInformation(object sender, RoutedEventArgs e)
        {
            SaniryRoleDataGrid.ItemsSource = await _rolesService.GetSanitaryRoles(App.CancellationToken);
        }
    }
}
