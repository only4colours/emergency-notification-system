using Microsoft.EntityFrameworkCore;
using template_service.Database.Entities;

namespace template_service.Database;

public class TemplateDbContext(DbContextOptions<TemplateDbContext> options) : DbContext(options)
{
    public DbSet<Template> Templates { get; init; } = null!;
}