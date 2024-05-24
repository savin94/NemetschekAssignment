using NemetschekAssignment.Models;

namespace NemetschekAssignment.Core.Dtos;
public class CreateNemetschekDocumentDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required NemetschekDocumentDocumentType Type { get; set; }
}
