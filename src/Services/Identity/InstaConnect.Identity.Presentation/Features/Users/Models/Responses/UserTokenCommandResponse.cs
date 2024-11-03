namespace InstaConnect.Identity.Web.Features.Users.Models.Responses;

public record UserTokenCommandResponse(string Value, DateTime ValidUntil);
