namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludePropertyFactory
{
    IEnumerable<IChatMessageIncludeProperty> Create(ICollection<ChatMessageIncludeProperty>? includeProperties);
}
