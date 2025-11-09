namespace InstaConnect.Posts.Domain.Features.Users.Models.Requests;

public record UserIncludeQuery(ICollection<UserIncludeProperty> Properties);
