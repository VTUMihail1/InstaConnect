using InstaConnect.Chats.Domain.Features.Common.Models.Requests;
using InstaConnect.Common.Infrastructure.Features.Data.Abstractions;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluder : IIncluder<User, ChatsIncludeType, ChatsDestinationType>;
