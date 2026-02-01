namespace InstaConnect.Identity.Domain.Features.RefreshTokens.Models.Requests;

public record RefreshTokenInclude(ICollection<RefreshTokenIncludeProperty> Properties) : IInclude<RefreshTokenIncludeProperty>;
