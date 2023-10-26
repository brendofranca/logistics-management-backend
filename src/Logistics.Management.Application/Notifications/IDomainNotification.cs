namespace Logistics.Management.Application.Notifications
{
    public interface IDomainNotification
    {
        void AddNotification(string message);

        bool HasNotifications();

        List<Notification> GetNotifications();
    }
}