using Presentation.Windows;

namespace Presentation.Components.Atomic
{
    public partial class HeaderUserControl
    {
        private readonly MainWindow _mainWindow;

        public HeaderUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }
    }
}
