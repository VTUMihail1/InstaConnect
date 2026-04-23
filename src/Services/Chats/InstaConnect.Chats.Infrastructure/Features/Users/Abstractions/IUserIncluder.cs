using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, ChatsIncludeType, ChatsDestinationType>;
