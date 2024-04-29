using recipient_service.Database.Entities;

namespace recipient_service.Database.Repositories;

public interface IRecipientsRepository
{
    public Task AddAsync(Recipient recipient);
    public Task<Recipient?> GetByIdAsync(Guid id);
    public Task<Recipient?> EditByIdAsync(Guid id, string? phoneNumber);
    public Task<Recipient?> DeleteByIdAsync(Guid id);
}