using InstaConnect.Common.Domain.Abstractions;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Helpers;
internal class FollowFactory : IFollowFactory
{
    private readonly IGuidProvider _guidProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public FollowFactory(
        IGuidProvider guidProvider,
        IDateTimeProvider dateTimeProvider)
    {
        _guidProvider = guidProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    public Follow Get(string followerId, string followingId)
    {
        var id = _guidProvider.NewGuid().ToString();
        var utcNow = _dateTimeProvider.GetUtcNow();
        var follow = new Follow(
            id,
            followerId,
            followingId,
            utcNow,
            utcNow);

        return follow;
    }
}
