using recipient_service.Database.Entities;

namespace recipient_service.Database.Repositories;

public class PostgresRecipientsRepository(RecipientDbContext db) : IRecipientsRepository
{
    public async Task AddAsync(Recipient recipient)
    {
        db.Recipients.Add(recipient);
        
        await db.SaveChangesAsync();
    }

    public async Task<Recipient?> GetByIdAsync(Guid id)
    {
        var recipient = await db.Recipients.FindAsync(id);
        
        return recipient ?? null;
    }

    public async Task<Recipient?> EditByIdAsync(Guid id, string phoneNumber)
    { 
        var recipient = await db.Recipients.FindAsync(id);
        if (recipient is null)
            return null;

        recipient.PhoneNumber = phoneNumber;

        db.Recipients.Update(recipient);
        await db.SaveChangesAsync();

        return recipient;
    }

    public async Task<Recipient?> DeleteByIdAsync(Guid id)
    {
        var recipient = await db.Recipients.FindAsync(id);
        if (recipient is null) 
            return null;
        
        db.Recipients.Remove(recipient);
        await db.SaveChangesAsync();

        return recipient;
    }
}