using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;

using MongoDB.Driver;
using InstaConnect.Chats.Domain.Features.Chats.Models.Entities;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncludeProperty : IIncludeProperty<Chat>
{
    public ChatIncludeProperty IncludeProperty { get; }
}
