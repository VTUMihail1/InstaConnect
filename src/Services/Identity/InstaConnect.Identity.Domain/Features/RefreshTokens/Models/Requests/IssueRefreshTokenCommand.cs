namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record IssueRefreshTokenCommand(string Name, string Password);
