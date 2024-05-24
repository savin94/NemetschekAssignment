using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    public async Task<ActionResult> Create(CreateAssetStatusCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = Policies.MinIntegrator)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Edit(EditAssetStatusCommand command)
    {
        var document = await context.Documents.FindAsync(id);
        if (document == null)
        {
            return false;
        }
        await mediator.Send(command);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Authorize(Policy = Policies.MinSuperAdmin)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(Guid id)
    {
        var command = new DeleteAssetStatusCommand { Id = id };
        await mediator.Send(command);

        return NoContent();
    }
}
