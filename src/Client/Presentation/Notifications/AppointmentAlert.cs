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
                .AddText("Andrés Felipe Galván")
                .AddText("Examen físco general")
                .AddAudio(new Uri("ms-winsoundevent:Notification.Mail"))
                .SetToastScenario(ToastScenario.Reminder)
                .AddAttributionText(DateTime.Now.ToLongDateString())
                .AddButton(new ToastButton()
                    .SetContent("Ver más detalles")
                    .AddArgument("action", "viewDetails"))
                .AddButton(new ToastButton()
                    .SetContent("Ignorar")
                    .AddArgument("action", "remindLater")
                    .SetBackgroundActivation())
                .Show();
        }
    }
}
