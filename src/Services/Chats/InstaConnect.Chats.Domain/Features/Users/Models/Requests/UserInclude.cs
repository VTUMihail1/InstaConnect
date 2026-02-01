namespace InstaConnect.Chats.Domain.Features.Users.Models.Requests;

public record UserInclude(ICollection<UserIncludeProperty> Properties);
