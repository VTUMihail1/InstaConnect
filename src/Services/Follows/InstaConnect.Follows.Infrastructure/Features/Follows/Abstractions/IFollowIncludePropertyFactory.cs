namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowIncludePropertyFactory
{
    IEnumerable<IFollowIncludeProperty> Create(ICollection<FollowIncludeProperty>? includeProperties);
}
