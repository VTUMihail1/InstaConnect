using InstaConnect.Common.Infrastructure.Abstractions;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;

using MongoDB.Driver;
using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Entities;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

public interface IChatMessageIncludeProperty : IIncludeProperty<ChatMessage>
{
    public ChatMessageIncludeProperty IncludeProperty { get; }
}
