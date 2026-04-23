using InstaConnect.Chats.Domain.Features.Common.Models.Requests;

namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

internal interface IUserIncluderFactory
    : IIncluderFactory<ChatsIncludeType, ChatsDestinationType, ChatsIncludeDescriptor, IUserIncluder, User>;
