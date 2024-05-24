using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Models;
using OndoNet.Data;
using System.Reflection.Metadata;

namespace NemetschekAssignment.Core.Services;
public class DocumentService(NemetschekDbContext context, IMapper mapper) : IDocumentService
{

    public async Task<IEnumerable<NemetschekDocument>> GetAllAsync()
    {
        return await context.Documents.ToListAsync();
    }

    public async Task<NemetschekDocument> GetByIdAsync(Guid id)
    {
        return await context.Documents.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<NemetschekDocument> CreateAsync(CreateNemetschekDocumentDto document)
    {
        context.Documents.Add(document);
        await context.SaveChangesAsync();
        return document;
    }

    public async Task<Document> UpdateAsync(Document document)
    {
        context.Entry(document).State = EntityState.Modified;
        await context.SaveChangesAsync();

        return document;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var document = await context.Documents.FindAsync(id);

        context.Documents.Remove(document);
        await context.SaveChangesAsync();

        return true;
    }
}
