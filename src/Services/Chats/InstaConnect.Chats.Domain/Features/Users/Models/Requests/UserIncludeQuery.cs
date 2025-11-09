namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UserIncludeQuery(ICollection<UserIncludeProperty> Properties);
