using InstaConnect.Chats.Domain.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, ChatsIncludeType, ChatsDestinationType>;
