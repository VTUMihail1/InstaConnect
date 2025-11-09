namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;
public interface IFollowByFollowerSortPropertyFactory
{
    IFollowByFollowerSortProperty Create(FollowByFollowerSortProperty sortProperty);
}
