namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

public record VerifyEmailConfirmationTokenRequest([FromRoute] string Token, [FromRoute] string UserId);
