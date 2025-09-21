namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

public record VerifyEmailConfirmationTokenApiRequest([FromRoute] string Id, [FromRoute] string Value);
