namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RefreshTokenIncludeQuery(ICollection<RefreshTokenIncludeProperty> Properties);
