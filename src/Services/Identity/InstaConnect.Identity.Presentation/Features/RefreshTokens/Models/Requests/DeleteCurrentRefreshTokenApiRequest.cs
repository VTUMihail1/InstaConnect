using InstaConnect.Common.Presentation.Binders.FromCookie;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record DeleteCurrentRefreshTokenApiRequest(
    [FromCookie(RefreshTokenCookieKeys.Id)] string Id,
    [FromCookie(RefreshTokenCookieKeys.Value)] string Value);
