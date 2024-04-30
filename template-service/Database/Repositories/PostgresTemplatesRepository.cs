using template_service.Database.Entities;

namespace template_service.Database.Repositories;

public class PostgresTemplatesRepository(TemplateDbContext db) : ITemplatesRepository
{
    public async Task AddAsync(Template template)
    {
        db.Templates.Add(template);
        
        await db.SaveChangesAsync();
    }

    public async Task<Template?> GetByIdAsync(Guid id)
    {
        var template = await db.Templates.FindAsync(id);
        
        return template ?? null;
    }

    public async Task<Template?> EditByIdAsync(Guid id, string? title, string? content)
    { 
        var template = await db.Templates.FindAsync(id);
        if (template is null)
            return null;
        
        if (title is not null)
            template.Title = title;
        if (content is not null)
            template.Content = content;

        db.Templates.Update(template);
        await db.SaveChangesAsync();

        return template;
    }

    public async Task<Template?> DeleteByIdAsync(Guid id)
    {
        var template = await db.Templates.FindAsync(id);
        if (template is null) 
            return null;
        
        db.Templates.Remove(template);
        await db.SaveChangesAsync();

        return template;
    }
}