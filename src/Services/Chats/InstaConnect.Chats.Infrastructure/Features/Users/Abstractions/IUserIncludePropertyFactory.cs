namespace InstaConnect.Chats.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludePropertyFactory
{
    IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties);
}
