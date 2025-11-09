namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;
internal class FollowByFollowerSortPropertyFactory : IFollowByFollowerSortPropertyFactory
{
    private readonly IEnumerable<IFollowByFollowerSortProperty> _followByFollowerSortProperties;

    public FollowByFollowerSortPropertyFactory(IEnumerable<IFollowByFollowerSortProperty> followByFollowerSortProperties)
    {
        _followByFollowerSortProperties = followByFollowerSortProperties;
    }

    public IFollowByFollowerSortProperty Create(FollowByFollowerSortProperty sortProperty)
    {
        var property = _followByFollowerSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new FollowByFollowerSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
