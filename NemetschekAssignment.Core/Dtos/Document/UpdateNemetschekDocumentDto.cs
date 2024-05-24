using NemetschekAssignment.Models;

namespace NemetschekAssignment.Core.Dtos;
public class UpdateNemetschekDocumentDto
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required NemetschekDocumentDocumentType Type { get; set; }
}
