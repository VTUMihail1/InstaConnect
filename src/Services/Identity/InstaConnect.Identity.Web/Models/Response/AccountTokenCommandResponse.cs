namespace InstaConnect.Identity.Web.Models.Response;

public record AccountTokenCommandResponse(string Type, string Value, DateTime ValidUntil);
