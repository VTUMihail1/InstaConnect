namespace InstaConnect.Follows.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<UserIncludeProperty> Properties);
