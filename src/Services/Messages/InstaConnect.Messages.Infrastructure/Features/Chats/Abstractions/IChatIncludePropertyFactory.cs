using InstaConnect.Chats.Domain.Features.Chats.Models.Requests;
using InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

namespace InstaConnect.Common.Infrastructure.Abstractions;

public interface IChatIncludePropertyFactory
{
    ICollection<IChatIncludeProperty> Create(ICollection<ChatIncludeProperty>? includeProperties);
}
