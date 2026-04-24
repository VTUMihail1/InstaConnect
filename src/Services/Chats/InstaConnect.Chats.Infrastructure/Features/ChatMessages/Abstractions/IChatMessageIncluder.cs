using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.ChatMessages.Abstractions;

internal interface IChatMessageIncluder : IIncluder<ChatMessage, ChatsIncludeType, ChatsDestinationType>;
