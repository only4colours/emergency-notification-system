using Microsoft.EntityFrameworkCore;
using notification_service.Database.Entities;

namespace notification_service.Database;

public class NotificationDbContext(DbContextOptions<NotificationDbContext> options) : DbContext(options)
{
    public DbSet<Notification> Notifications { get; init; } = null!;
}