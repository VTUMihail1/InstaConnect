namespace InstaConnect.Chats.Domain.Models.Requests;

public record ChatsIncludeDescriptor(
    ChatsDestinationType DestinationType,
    ChatsIncludeType IncludeType)
    : IIncludeDescriptor<ChatsDestinationType, ChatsIncludeType>;
