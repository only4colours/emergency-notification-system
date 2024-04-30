using template_service.Database.Entities;

namespace template_service.Database.Repositories;

public interface ITemplatesRepository
{
    public Task AddAsync(Template template);
    public Task<Template?> GetByIdAsync(Guid id);
    public Task<Template?> EditByIdAsync(Guid id, string? title, string? content);
    public Task<Template?> DeleteByIdAsync(Guid id);
}