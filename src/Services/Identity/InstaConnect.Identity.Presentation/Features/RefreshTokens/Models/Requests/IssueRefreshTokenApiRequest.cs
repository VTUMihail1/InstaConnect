using InstaConnect.Identity.Presentation.Features.ForgotPasswordTokens.Models.Bodies;

namespace InstaConnect.Identity.Presentation.Features.RefreshTokens.Models.Requests;

public record IssueRefreshTokenApiRequest(
    [FromRoute] string Name,
    [FromBody] IssueRefreshTokenApiBody Body);
