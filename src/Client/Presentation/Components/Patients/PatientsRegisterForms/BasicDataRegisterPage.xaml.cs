using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Presentation.Controllers.Http;
using Presentation.Windows;

namespace Presentation.Components.Patients.PatientsRegisterForms
{
    public partial class BasicDataRegisterPage : Page
    {
        private readonly MainWindow           _mainWindow;
        private readonly ContextDataRetriever _contextData;

        public BasicDataRegisterPage(MainWindow mainWindow, ContextDataRetriever contextData)
        {
            _mainWindow  = mainWindow;
            _contextData = contextData;
            InitializeComponent();
            Loaded += OnLoadedPage;
        }

        private void GoToNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            var nextPage = _mainWindow.GetComponent<ContactDataRegisterPage>();
            _mainWindow.GetComponent<RegisterPatientUserControl>().NavigateTo(nextPage);
        }

        private async void OnLoadedPage(object sender, RoutedEventArgs e)
        {
            await PopulateFormOptions();
        }

        private async Task PopulateFormOptions()
        {
            BasicDataDocTypeComboBox.ComboBoxItemsSource =
                await _contextData.GetIdTypes(App.CancellationToken);
            BasicDataGenreComboBox.ComboBoxItemsSource = new[] { "Masculino", "Femenino" };
        }
    }
}
