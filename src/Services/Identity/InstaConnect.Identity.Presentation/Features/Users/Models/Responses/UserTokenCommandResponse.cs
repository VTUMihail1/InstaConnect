namespace InstaConnect.Identity.Presentation.Features.Users.Models.Responses;

public record UserTokenCommandResponse(string Value, DateTimeOffset ValidUntil);
