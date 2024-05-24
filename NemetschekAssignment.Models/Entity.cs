using System.ComponentModel.DataAnnotations;

namespace NemetschekAssignment.Models;
public class Entity<T> : IEntity where T : struct
{
    public virtual T Id { get; set; }
    [Required] public required DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
    [Required] public required DateTimeOffset UpdatedAt { get; set; } = DateTime.UtcNow;
}