using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NemetschekAssignment.Core.Dtos;
using NemetschekAssignment.Core.Services;
using NemetschekAssignment.Models;

namespace NemetschekAssignment.Controllers;
[ApiController]
[Route("api/documents")]
public class DocumentsController(IMapper mapper, IDocumentService documentService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NemetschekDocumentDto>>> GetAll()
    {
        var documents = await documentService.GetAllAsync();
        return Ok(mapper.Map<IEnumerable<NemetschekDocument>, List<NemetschekDocumentDto>>(documents));
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Create(CreateNemetschekDocumentDto dto)
    {
        var document = await documentService.CreateAsync(dto);

        return Ok(mapper.Map<NemetschekDocument>(document));
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Edit(Guid id, UpdateNemetschekDocumentDto dto)
    {
        var document = documentService.GetByIdAsync(id);
        if (document == null)
        {
            return NotFound();
        }

       var updatedDocumet =  await documentService.UpdateAsync(dto);


        return Ok(mapper.Map<NemetschekDocumentDto>(updatedDocumet));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var document = documentService.GetByIdAsync(id);
        if (document == null)
        {
            return NotFound();
        }

       await documentService.DeleteAsync(id);

        return NoContent();
    }
}
