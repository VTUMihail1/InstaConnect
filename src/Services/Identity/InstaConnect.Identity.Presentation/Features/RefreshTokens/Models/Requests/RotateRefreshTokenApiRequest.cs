using InstaConnect.Common.Presentation.Binders.FromCookie;
using InstaConnect.Identity.Presentation.Features.RefreshTokens.Utilities;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record RotateRefreshTokenApiRequest(
    [FromCookie(RefreshTokenCookieKeys.Id)] string Id,
    [FromCookie(RefreshTokenCookieKeys.Value)] string Value);
