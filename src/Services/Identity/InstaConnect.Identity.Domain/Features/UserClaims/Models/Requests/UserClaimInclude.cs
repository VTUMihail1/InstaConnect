namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimInclude(ICollection<UserClaimIncludeProperty> Properties);
