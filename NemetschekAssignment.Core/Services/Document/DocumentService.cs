using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Models;
using OndoNet.Data;

namespace NemetschekAssignment.Core.Services;
public class DocumentService(NemetschekDbContext context, IMapper mapper) : IDocumentService
{

    public async Task<IEnumerable<NemetschekDocument>> GetAllAsync()
    {
        return await context.Documents.ToListAsync();
    }

    public async Task<NemetschekDocument?> GetByIdAsync(Guid id) => await context.Documents.FirstOrDefaultAsync(x => x.Id == id);

    public async Task<NemetschekDocument> CreateAsync(CreateNemetschekDocumentDto dto)
    {
        var document = mapper.Map<CreateNemetschekDocumentDto, NemetschekDocument>(dto);

        await context.Documents.AddAsync(document);
        await context.SaveChangesAsync();

        return document;
    }

    public async Task<NemetschekDocument> UpdateAsync(UpdateNemetschekDocumentDto dto)
    {
        // No need to use FirstOrDefaultAsync and check if value is null because we check that in the controller
        var dbModel = await context.Documents.FirstAsync(x => x.Id == dto.Id);

        dbModel.Name = dto.Name!;
        dbModel.Description = dto.Description;
        dbModel.Type = dto.Type;
        dbModel.UpdatedAt = DateTimeOffset.Now;

        context.Documents.Update(dbModel);
        await context.SaveChangesAsync();

        return dbModel;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        // No need to use FirstOrDefaultAsync and check if value is null because we check that in the controller
        var document = await context.Documents.FirstAsync(x => x.Id == id);

        context.Documents.Remove(document);
        await context.SaveChangesAsync();

        return true;
    }
}
