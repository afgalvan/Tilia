using System.Windows.Controls;
using Presentation.Utils;

namespace Presentation.Components.MedAppointment
{
    /// <summary>
    /// Lógica de interacción para DefaultMedAppointmentPanelUserControl.xaml
    /// </summary>
    public partial class DefaultMedAppointmentPanelUserControl : UserControl
    {
        private readonly ContentAreaUtil _contentAreaUtil;

        public DefaultMedAppointmentPanelUserControl(ContentAreaUtil contentAreaUtil)
        {
            _contentAreaUtil = contentAreaUtil;
            InitializeComponent();
        }
    }
}
