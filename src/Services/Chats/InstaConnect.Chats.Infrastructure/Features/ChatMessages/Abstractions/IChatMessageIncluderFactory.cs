using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessageIncluderFactory
    : IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IChatMessageIncluder, ChatMessage>;
