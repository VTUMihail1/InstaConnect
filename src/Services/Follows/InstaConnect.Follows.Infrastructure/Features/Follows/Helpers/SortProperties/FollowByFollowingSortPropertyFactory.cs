namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers.SortProperties;

internal class FollowByFollowingSortPropertyFactory : IFollowByFollowingSortPropertyFactory
{
    private readonly IEnumerable<IFollowByFollowingSortProperty> _followByFollowingSortProperties;

    public FollowByFollowingSortPropertyFactory(IEnumerable<IFollowByFollowingSortProperty> followByFollowingSortProperties)
    {
        _followByFollowingSortProperties = followByFollowingSortProperties;
    }

    public IFollowByFollowingSortProperty Create(FollowByFollowingSortProperty sortProperty)
    {
        var property = _followByFollowingSortProperties.FirstOrDefault(s => s.SortProperty == sortProperty);

        if (property == null)
        {
            throw new FollowByFollowingSortPropertyNotSupportedException(sortProperty);
        }

        return property;
    }
}
