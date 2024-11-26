namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserTokenCommandResponse(string Value, DateTime ValidUntil);
