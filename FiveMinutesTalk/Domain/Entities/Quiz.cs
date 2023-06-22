using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveMinutesTalk.Domain.Entities;

public class Quiz : EntityBase
{
    [Required] 
    public string Title { get; set; } = "Опрос";
    
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime CreationDate { get; set; }
    
    public Guid OwnerId { get; set; }
}