using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NemetschekAssignment.Models;
[Table("Documents")]
public class NemetschekDocument : Entity<Guid>
{
    [Required] public required string Name { get; set; }
    [Required] public required string Description { get; set; }
    [Required] public required NemetschekDocumentDocumentType Type { get; set; }
}