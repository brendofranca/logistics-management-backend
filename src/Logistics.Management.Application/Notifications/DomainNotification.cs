using System.Diagnostics.CodeAnalysis;

namespace Logistics.Management.Application.Notifications
{
    [ExcludeFromCodeCoverage]
    public class DomainNotification : IDomainNotification
    {
        private readonly List<Notification> _notifications;

        public DomainNotification() => _notifications = new List<Notification>();

        public void AddNotification(string message)
        {
            var notification = new Notification(message);

            _notifications.Add(notification);
        }

        public bool HasNotifications() => _notifications.Any();

        public List<Notification> GetNotifications() => _notifications;
    }
}