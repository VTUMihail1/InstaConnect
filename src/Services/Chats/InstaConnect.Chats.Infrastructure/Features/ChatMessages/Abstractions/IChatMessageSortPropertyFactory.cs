namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;
public interface IChatMessageSortPropertyFactory
{
    IChatMessageSortProperty Create(ChatMessageSortProperty sortProperty);
}
