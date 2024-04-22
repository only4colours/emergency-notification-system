namespace notification_service.Database.Entities;

public class Notification
{
    public NotificationType Type { get; set; }
    public NotificationStatus Status { get; set; }
}