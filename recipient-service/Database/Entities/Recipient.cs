using System.ComponentModel.DataAnnotations.Schema;

namespace recipient_service.Database.Entities;

public class Recipient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    public string? PhoneNumber { get; set; }
}