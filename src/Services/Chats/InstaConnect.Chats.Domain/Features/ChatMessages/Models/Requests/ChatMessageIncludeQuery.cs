namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageIncludeQuery(ICollection<ChatMessageIncludeProperty> Properties);
