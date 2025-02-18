namespace InstaConnect.Identity.Presentation.Features.EmailConfirmationTokens.Models.Requests;

public record AddEmailConfirmationTokenRequest([FromRoute] string Email);
