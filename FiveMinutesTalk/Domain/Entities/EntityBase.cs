using System.ComponentModel.DataAnnotations;

namespace FiveMinutesTalk.Domain.Entities;

public abstract class EntityBase
{
    [Required]
    public Guid Id { get; set; }
}