using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Add;
using InstaConnect.Identity.Application.Features.ForgotPasswordTokens.Commands.Verify;

namespace InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Controllers.v1;

[ApiVersion(ForgotPasswordTokenRoutes.Version1)]
[Route(ForgotPasswordTokenRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class ForgotPasswordTokenController : ControllerBase
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public ForgotPasswordTokenController(
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // POST: api/users/user@example.com/forgot-password-tokens
    [HttpPost(ForgotPasswordTokenRoutes.Add)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddAsync(
        AddForgotPasswordTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<AddForgotPasswordTokenCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }

    // PUT: api/users/5f0f2dd0-e957-4d72-8141-767a36fc6e95/forgot-password-tokens/Q2ZESjhBTS9wV1d6MW9KS2hVZzBWd1oydStIellLdmhPU0VaNGl5zmtkltuvbahvcxqzsdg/verify
    [HttpPut(ForgotPasswordTokenRoutes.Verify)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> VerifyAsync(
        VerifyForgotPasswordTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<VerifyForgotPasswordTokenCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
