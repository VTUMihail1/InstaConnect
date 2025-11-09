namespace InstaConnect.Follows.Infrastructure.Features.Follows.Abstractions;

public interface IFollowByFollowingSortPropertyFactory
{
    IFollowByFollowingSortProperty Create(FollowByFollowingSortProperty sortProperty);
}
