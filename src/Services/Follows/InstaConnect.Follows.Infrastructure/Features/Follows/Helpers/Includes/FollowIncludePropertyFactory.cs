namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.Includes;
internal class FollowIncludePropertyFactory : IFollowIncludePropertyFactory
{
    private readonly IEnumerable<IFollowIncludeProperty> _followIncludeProperty;

    public FollowIncludePropertyFactory(IEnumerable<IFollowIncludeProperty> followIncludeProperty)
    {
        _followIncludeProperty = followIncludeProperty;
    }

    public IEnumerable<IFollowIncludeProperty> Create(ICollection<FollowIncludeProperty>? includeProperties)
    {
        if (includeProperties == null)
        {
            return [];
        }

        var properties = _followIncludeProperty.Where(s => includeProperties.Contains(s.IncludeProperty));

        if (properties.IsEmpty())
        {
            throw new FollowIncludePropertiesNotSupportedException(includeProperties);
        }

        return properties;
    }
}
