using System.Diagnostics.CodeAnalysis;

namespace Logistics.Management.Application.Notifications
{
    [ExcludeFromCodeCoverage]
    public class Notification
    {
        public string Message { get; private set; }

        public Notification(string message) => Message = message;
    }
}