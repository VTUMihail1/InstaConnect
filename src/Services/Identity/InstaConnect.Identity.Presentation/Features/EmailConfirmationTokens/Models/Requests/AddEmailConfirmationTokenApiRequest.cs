namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

public record AddEmailConfirmationTokenApiRequest([FromRoute] string Name);
