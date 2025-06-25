using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.EmailConfirmationTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Controllers.v1;

[ApiVersion(EmailConfirmationTokenRoutes.Version1)]
[Route(EmailConfirmationTokenRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class EmailConfirmationTokenController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public EmailConfirmationTokenController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // POST: api/users/user@example.com/email-confirmation-tokens
    [HttpPost(EmailConfirmationTokenRoutes.Add)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddAsync(
        AddEmailConfirmationTokenRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddEmailConfirmationTokenCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

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
        var commandRequest = _applicationMapper.Map<VerifyEmailConfirmationTokenCommand>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
