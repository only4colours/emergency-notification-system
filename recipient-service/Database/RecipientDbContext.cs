using Microsoft.EntityFrameworkCore;
using recipient_service.Database.Entities;

namespace recipient_service.Database;

public class RecipientDbContext(DbContextOptions<RecipientDbContext> options) : DbContext(options)
{
    public DbSet<Recipient> Recipients { get; init; } = null!;
}