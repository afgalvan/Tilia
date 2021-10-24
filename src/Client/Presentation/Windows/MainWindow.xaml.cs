using System.Windows.Controls;
using Presentation.Components.Atomic;
using Presentation.Components.Dashboard;

namespace Presentation.Windows
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainContentArea.Content    = new DashboardUserControl();
            HeaderContentArea.Content  = new HeaderUserControl(this);
            SideBarContentArea.Content = new SidebarUserControl(this);
        }

        public void ChangeMainContentArea(UserControl content)
        {
            if (content == null)
            {
                MainContentArea.Content = new DashboardUserControl();
                return;
            }

            MainContentArea.Content = content;
        }
    }
}