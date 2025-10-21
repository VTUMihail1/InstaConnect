using InstaConnect.ChatMessages.Domain.Features.ChatMessages.Models.Requests;
using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IChatMessageIncludePropertyFactory
{
    ICollection<IChatMessageIncludeProperty> Create(ICollection<ChatMessageIncludeProperty>? includeProperties);
}
