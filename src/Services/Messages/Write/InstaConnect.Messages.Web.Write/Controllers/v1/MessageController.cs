using Asp.Versioning;
using AutoMapper;
using InstaConnect.Messages.Business.Commands.Messages.AddMessage;
using InstaConnect.Messages.Business.Commands.Messages.DeleteMessage;
using InstaConnect.Messages.Business.Commands.Messages.UpdateMessage;
using InstaConnect.Messages.Web.Models.Requests.Messages;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Messages.Web.Controllers.v1;

[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/messages")]
[Authorize]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class MessageController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;

    public MessageController(
        IMapper mapper,
        ISender sender)
    {
        _mapper = mapper;
        _sender = sender;
    }

    // POST: api/messages
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddMessageRequest request)
    {
        var commandQuery = _mapper.Map<AddMessageCommand>(request);
        await _sender.Send(commandQuery);

        return NoContent();
    }

    // PUT: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateAsync(UpdateMessageRequest request)
    {
        var commandQuery = _mapper.Map<UpdateMessageCommand>(request);
        await _sender.Send(commandQuery);

        return NoContent();
    }

    //DELETE: api/messages/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeleteMessageRequest request)
    {
        var commandQuery = _mapper.Map<DeleteMessageCommand>(request);
        await _sender.Send(commandQuery);

        return NoContent();
    }
}

