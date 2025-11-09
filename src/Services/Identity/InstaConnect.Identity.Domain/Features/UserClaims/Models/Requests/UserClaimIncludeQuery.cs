namespace InstaConnect.Identity.Domain.Features.UserClaims.Models.Requests;

public record UserClaimIncludeQuery(ICollection<UserClaimIncludeProperty> Properties);
