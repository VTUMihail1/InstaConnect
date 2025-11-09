namespace InstaConnect.Chats.Infrastructure.Features.Chats.Abstractions;

public interface IChatIncludePropertyFactory
{
    IEnumerable<IChatIncludeProperty> Create(ICollection<ChatIncludeProperty>? includeProperties);
}
