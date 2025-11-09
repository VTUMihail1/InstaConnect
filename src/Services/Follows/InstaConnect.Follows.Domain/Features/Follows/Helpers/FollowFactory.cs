namespace InstaConnect.Follows.Domain.Features.Follows.Helpers;

internal class FollowFactory : IFollowFactory
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public FollowFactory(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public Follow Create(string followerId, string followingId)
    {
        var utcNow = _dateTimeProvider.GetOffsetUtcNow();
        var follow = new Follow(
            followerId,
            followingId,
            utcNow,
            utcNow);

        return follow;
    }
}
