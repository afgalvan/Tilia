using Presentation.Components.Atomic;

namespace Presentation.Windows
{
    public partial class LoginWindow
    {
        public LoginWindow()
        {
            InitializeComponent();
            UsernameContentArea.Content = new UsernameUserControl();
            PasswordContentArea.Content = new PasswordUserControl();
        }
    }
}
