using System.Linq.Expressions;

using InstaConnect.Follows.Infrastructure.Features.Users.Extensions;

using MongoDB.Driver;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Extensions;
public static class FollowFilterExtensions
{
    public static FilterDefinition<Follow> GetFilter(this FollowByFollowerFilterQuery filter)
    {
        var followerId = filter.FollowerId.GetFilterForIdEquals<Follow>(p => p.Id.FollowerId.Id);
        var followingName = filter.FollowingName.GetFilterForNameStartsWith<Follow>(p => p.Following!.Name.Value);

        return Builders<Follow>.Filter.And(followerId, followingName);
    }

    public static FilterDefinition<Follow> GetFilter(this FollowByFollowingFilterQuery filter)
    {
        var followingId = filter.FollowingId.GetFilterForIdEquals<Follow>(p => p.Id.FollowingId.Id);
        var followerName = filter.FollowerName.GetFilterForNameStartsWith<Follow>(p => p.Follower!.Name.Value);

        return Builders<Follow>.Filter.And(followingId, followerName);
    }

    public static FilterDefinition<Follow> GetFilter(this FollowId filter)
    {
        return filter.GetFilterForIdEquals<Follow>(p => p.Id.FollowerId.Id, p => p.Id.FollowingId.Id);
    }

    public static FilterDefinition<T> GetFilterForIdEquals<T>(this FollowId filter,
        Expression<Func<T, object>> followerIdField,
        Expression<Func<T, object>> followingIdField)
    {
        var followerId = filter.FollowerId.GetFilterForIdEquals(followerIdField);
        var followingId = filter.FollowingId.GetFilterForIdEquals(followingIdField);

        return Builders<T>.Filter.And(followerId, followingId);
    }
}
