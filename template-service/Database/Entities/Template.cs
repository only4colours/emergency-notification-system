using System.ComponentModel.DataAnnotations.Schema;

namespace template_service.Database.Entities;

public class Template
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    // public ICollection<> Recipients = new List<>();
}