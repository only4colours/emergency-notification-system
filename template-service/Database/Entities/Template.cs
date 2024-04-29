using System.ComponentModel.DataAnnotations.Schema;

namespace template_service.Database.Entities;

public class Template
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }
    
    public string? Title { get; set; }
    public string? Content { get; set; }
    
    public List<Guid> RecipientIds { get; set; } = [];
}