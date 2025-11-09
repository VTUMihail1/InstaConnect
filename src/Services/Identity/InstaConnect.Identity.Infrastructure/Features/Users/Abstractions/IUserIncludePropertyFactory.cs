namespace InstaConnect.Identity.Infrastructure.Features.Users.Abstractions;

public interface IUserIncludePropertyFactory
{
    IEnumerable<IUserIncludeProperty> Create(ICollection<UserIncludeProperty>? includeProperties);
}
