using InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Add;
using InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;
using InstaConnect.RefreshTokens.Application.Features.RefreshTokens.Commands.Delete;
using InstaConnect.Common.Infrastructure.Abstractions;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Controllers.v1;

[ApiVersion(RefreshTokenRoutes.Version1)]
[Route(RefreshTokenRoutes.Resource)]
[EnableRateLimiting(AppPolicies.RateLimiterPolicy)]
public class RefreshTokenController : ControllerBase
{
    private readonly ICookieStore _cookieStore;
    private readonly IApplicationMapper _applicationMapper;
    private readonly IApplicationSender _applicationSender;

    public RefreshTokenController(
        ICookieStore cookieStore,
        IApplicationMapper applicationMapper,
        IApplicationSender applicationSender)
    {
        _cookieStore = cookieStore;
        _applicationMapper = applicationMapper;
        _applicationSender = applicationSender;
    }

    // POST: api/users/name/refresh-tokens/issue
    [HttpPost(RefreshTokenRoutes.Issue)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IssueRefreshTokenApiResponse>> IssueAsync(
        IssueRefreshTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<IssueRefreshTokenCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);

        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, commandResponse.RefreshToken.Id, commandResponse.RefreshToken.ExpiresAt);
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, commandResponse.RefreshToken.Value, commandResponse.RefreshToken.ExpiresAt);

        var response = _applicationMapper.Map<IssueRefreshTokenApiResponse>(commandResponse);

        return Ok(response);
    }

    // POST: api/users/current/refresh-tokens/current/rotate
    [HttpPost(RefreshTokenRoutes.CurrentRotate)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RotateRefreshTokenApiResponse>> RotateAsync(
        RotateRefreshTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<RotateRefreshTokenCommandRequest>(request);
        var commandResponse = await _applicationSender.SendAsync(commandRequest, cancellationToken);

        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Id, commandResponse.RefreshToken.Id, commandResponse.RefreshToken.ExpiresAt);
        _cookieStore.SetHttpOnly(RefreshTokenCookieKeys.Value, commandResponse.RefreshToken.Value, commandResponse.RefreshToken.ExpiresAt);

        var response = _applicationMapper.Map<RotateRefreshTokenApiResponse>(commandResponse);

        return Ok(response);
    }


    // DELETE: api/users/current/refresh-tokens/current
    [HttpDelete(RefreshTokenRoutes.Current)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteCurrentAsync(
        DeleteCurrentRefreshTokenApiRequest request,
        CancellationToken cancellationToken)
    {
        var commandRequest = _applicationMapper.Map<DeleteCurrentRefreshTokenCommandRequest>(request);
        await _applicationSender.SendAsync(commandRequest, cancellationToken);

        return NoContent();
    }
}
