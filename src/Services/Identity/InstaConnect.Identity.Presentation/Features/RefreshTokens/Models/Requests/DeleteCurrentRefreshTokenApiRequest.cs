using InstaConnect.Identity.Presentation.Features.RefreshTokens.Binders.FromCookie;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record DeleteCurrentRefreshTokenApiRequest(
    [RefreshTokenIdFromCookie] string Id,
    [RefreshTokenValueFromCookie] string Value);
