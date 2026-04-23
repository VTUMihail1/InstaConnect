using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

internal interface IChatIncluder : IIncluder<Chat, ChatsIncludeType, ChatsDestinationType>;
