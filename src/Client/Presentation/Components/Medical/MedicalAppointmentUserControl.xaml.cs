using System;
using System.Globalization;
using System.Windows.Controls;

namespace Presentation.Components.Medical
{
    public partial class MedicalAppointmentUserControl : UserControl
    {
        public MedicalAppointmentUserControl()
        {
            InitializeComponent();
            ActualDateText.Text = DateTime.Now.ToString(CultureInfo.InvariantCulture);
        }
    }
}
