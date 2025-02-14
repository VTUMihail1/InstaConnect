using Asp.Versioning;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Utilities;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Presentation.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

[ApiVersion(EmailConfirmationTokenRoutes.Version1)]
[Route(EmailConfirmationTokenRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class EmailConfirmationTokenController : ControllerBase
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IInstaConnectSender _instaConnectSender;

    public EmailConfirmationTokenController(
        IInstaConnectMapper instaConnectMapper,
        IInstaConnectSender instaConnectSender)
    {
        _instaConnectMapper = instaConnectMapper;
        _instaConnectSender = instaConnectSender;
    }

    // POST: api/users/user@example.com/email-confirmation-tokens
    [HttpPost(EmailConfirmationTokenRoutes.Add)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddAsync(
        AddEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<AddEmailConfirmationTokenCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // PUT: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/email-confirmation-tokens/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg/verify
    [HttpPut(EmailConfirmationTokenRoutes.Verify)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> VerifyAsync(
        VerifyEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _instaConnectMapper.Map<VerifyEmailConfirmationTokenCommand>(request);
        await _instaConnectSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
