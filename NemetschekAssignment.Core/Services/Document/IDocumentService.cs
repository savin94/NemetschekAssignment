using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Models;
using System.Reflection.Metadata;

namespace NemetschekAssignment.Core.Services;
public interface IDocumentService
{
    Task<IEnumerable<NemetschekDocument>> GetAllAsync();
    Task<NemetschekDocument?> GetByIdAsync(Guid id);
    Task<NemetschekDocument> CreateAsync(CreateNemetschekDocumentDto document);
    Task<NemetschekDocument> UpdateAsync(UpdateNemetschekDocumentDto document);
    Task<bool> DeleteAsync(Guid id);
}
