namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record IssueRefreshTokenCommand(Name Name, string Password);
