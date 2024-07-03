using Asp.Versioning;
using AutoMapper;
using InstaConnect.Follows.Write.Business.Commands.Follows.AddFollow;
using InstaConnect.Follows.Write.Business.Commands.Follows.DeleteFollow;
using InstaConnect.Follows.Write.Web.Models.Requests.Follows;
using InstaConnect.Shared.Web.Abstractions;
using InstaConnect.Shared.Web.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Follows.Write.Web.Controllers.v1;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/follows")]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class FollowController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ISender _sender;
    private readonly ICurrentUserContext _currentUserContext;

    public FollowController(
        IMapper mapper,
        ISender sender,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _sender = sender;
        _currentUserContext = currentUserContext;
    }

    // POST: api/follows
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddAsync(AddFollowRequest request)
    {
        var currentUserModel = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<AddFollowCommand>(request);
        _mapper.Map(currentUserModel, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }

    //DELETE: api/follows/5f0f2dd0-e957-4d72-8141-767a36fc6e95
    [HttpDelete("{id}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(DeleteFollowRequest request)
    {
        var currentUserModel = _currentUserContext.GetCurrentUser();
        var commandRequest = _mapper.Map<DeleteFollowCommand>(request);
        _mapper.Map(currentUserModel, commandRequest);
        await _sender.Send(commandRequest);

        return NoContent();
    }
}
