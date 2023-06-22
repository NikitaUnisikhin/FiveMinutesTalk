using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiveMinutesTalk.Domain.Entities;

public class Quiz : EntityBase
{
    [Required] 
    public string Title { get; set; } = "Опрос";

    public DateTime EndDate { get; set; }
    
    public Guid OwnerId { get; set; }
}