using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Models;
using System.Reflection.Metadata;

namespace NemetschekAssignment.Core.Services;
public interface IDocumentService
{
    Task<IEnumerable<NemetschekDocument>> GetAllAsync();
    Task<NemetschekDocument> GetByIdAsync(int id);
    Task<NemetschekDocument> CreateAsync(CreateNemetschekDocumentDto document);
    Task<NemetschekDocument> UpdateAsync(UpdateNemetschekDocumentDto document);
    Task<bool> DeleteAsync(int id);
}
