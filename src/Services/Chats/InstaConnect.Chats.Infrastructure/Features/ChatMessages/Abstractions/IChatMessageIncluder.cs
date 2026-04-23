using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessageIncluder : IIncluder<ChatMessage, ChatsIncludeType, ChatsDestinationType>;
