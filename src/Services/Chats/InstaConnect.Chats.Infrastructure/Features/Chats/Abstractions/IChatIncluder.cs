using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

internal interface IChatIncluder : IIncluder<Chat, ChatsIncludeType, ChatsDestinationType>;
