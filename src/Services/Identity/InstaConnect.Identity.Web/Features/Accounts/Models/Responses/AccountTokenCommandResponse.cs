namespace InstaConnect.Identity.Web.Features.Accounts.Models.Responses;

public record AccountTokenCommandResponse(string Type, string Value, DateTime ValidUntil);
