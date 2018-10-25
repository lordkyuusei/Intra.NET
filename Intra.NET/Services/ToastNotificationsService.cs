using Windows.UI.Notifications;

namespace Intra.NET.Services
{
    internal partial class ToastNotificationsService : IToastNotificationsService
    {
        public void ShowToastNotification(ToastNotification toastNotification)
        {
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }
    }
}
