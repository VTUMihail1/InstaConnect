namespace InstaConnect.Chats.Domain.Features.ChatMessages.Models.Requests;

public record ChatMessageInclude(ICollection<ChatMessageIncludeProperty> Properties);
