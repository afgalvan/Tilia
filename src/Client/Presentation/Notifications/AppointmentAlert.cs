using System;
using Microsoft.Toolkit.Uwp.Notifications;

namespace Presentation.Notifications
{
    public static class AppointmentAlert
    {
        public static void Show()
        {
            new ToastContentBuilder()
                .AddArgument("action", "viewConversation")
                .AddText("Cita médica.")
                .AddText("Bienvenido a tilia!")
                .AddCustomTimeStamp(DateTime.Now)
                .AddAudio(new Uri("ms-winsoundevent:Notification.Mail"))
                .SetToastScenario(ToastScenario.Reminder)
                .Show();
        }
    }
}
